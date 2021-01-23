    using System;
    using System.IO;
    using System.Collections.Generic;
    using ConsoleApplication8;
    
    namespace IntroCS
    {
        public class PlayCasino
        {
            private static Random rand = new Random();
            private static List<Casino> games = new List<Casino>();
    
            private static const int INVALID_CODE = -111;
            private static const int EXIT_CODE = 4;
            public static void Main()
            {
    
                int choosen = INVALID_CODE;
                while (choosen != EXIT_CODE)
                {
                    switch (choosen)
                    {
                        case INVALID_CODE:
                            choosen = DisplayMenu();
                            break;
                        case 0:
                            displayHelp();
                            choosen = INVALID_CODE;
                            break;
                        case 1:
                            games.Add(new BlackJack());
                            games[games.Count-1].PlayGames();
                            break;
                        case 2:
                            games.Add(new QuarterGame());
                            games[games.Count-1].PlayGames();
                            break;
                        default:
                            DisplayMenu();
                            break;
                    }
                }
            }
    
            private static void displayHelp()
            {
                Console.WriteLine("Accessing the Help Menu!" + "\n");// this is where we will print directions/ help menus
            }
    
            private static int DisplayMenu()
            {
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("(0 for help)");
                Console.WriteLine("(1 for blackjack)");
                Console.WriteLine("(2 for Quarter Game)");
                Console.WriteLine("Please enter an integer to choose your game: ");
                string input = Console.ReadLine();
                int number;
                if (Int32.TryParse(input, out number))
                    return number;
                else
                {
                    Console.WriteLine("Please Try an Integer");
                    return INVALID_CODE;
                }
            }
        }
    }
