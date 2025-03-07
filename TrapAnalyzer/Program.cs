using System;
using System.Diagnostics;
using System.Linq;

namespace TrapAnalyzer
{
    public class Program
    {
        /// <summary>
        /// Main method. Do not change it!
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
            // DO NOT CHANGE THIS METHOD!
            TrapType trap = Enum.Parse<TrapType>(args[0]);
            PlayerGear gear = ParseGear(args);
            bool survives = CanSurviveTrap(trap, gear);
            DisplayResult(trap, survives);
            // DO NOT CHANGE THIS METHOD!
        }

        /// <summary>
        /// Parse the command line arguments to get the player gear.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>The player gear.</returns>
        private static PlayerGear ParseGear(string[] args)
        {
            // ////////// //
            // CHANGE ME! //
            // ////////// //
            
            /*
             * // D e a c t i v a t e Tank r o l e
                myRoles &= ~WoWRoles . Tank ;
                // T o g gle ( s w i t c h ) Damage r o l e
                myRoles ^= WoWRoles . Damage ;
                 */
            
            PlayerGear playerGear = PlayerGear.Helmet | PlayerGear.Shield | PlayerGear.Boots;
            foreach (PlayerGear gear in Enum.GetValues(typeof(PlayerGear)))
            {
                playerGear &= gear;
            }
            foreach (string arg in args.ToList().Slice(1, args.ToList().Count-1))
            {
                PlayerGear gear = Enum.Parse<PlayerGear>(arg);
                if (gear != PlayerGear.None)
                {
                    playerGear ^= gear;
                }
            }
            return playerGear;
        }

        /// <summary>
        /// Can the player survive the trap given the gear it has?
        /// </summary>
        /// <param name="trap">The trap the player falls into.</param>
        /// <param name="gear">The gear the player has.</param>
        /// <returns>Wether the player survived the trap or not.</returns>
        private static bool CanSurviveTrap(TrapType trap, PlayerGear gear)
        {
            // ////////// //
            // CHANGE ME! //
            // ////////// //
            switch (trap)
            {
                case TrapType.FallingRocks:
                    return (gear & PlayerGear.Helmet) == PlayerGear.Helmet;
                case TrapType.SpinningBlades:
                    return (gear & PlayerGear.Shield) == PlayerGear.Shield;
                case TrapType.PoisonGas:
                    return (gear & PlayerGear.Helmet) == PlayerGear.Helmet && (gear & PlayerGear.Shield) == PlayerGear.Shield;
                case TrapType.LavaPit:
                    return (gear & PlayerGear.Boots) == PlayerGear.Boots;
            }
            return false;
        }

        /// <summary>
        /// Display information on wether the player survived the trap or not.
        /// </summary>
        /// <param name="trap">The trap the player has fallen into.</param>
        private static void DisplayResult(TrapType trap, bool survives)
        {
            // ////////// //
            // CHANGE ME! //
            // ////////// //
            string text = survives ? "survives" : "dies due to";
            Console.WriteLine($"Player {text} {trap.ToString()}");
        }
    }
}