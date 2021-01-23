    public static void Main()
        {
            Console.WriteLine ("MAIN MENU");
            Console.WriteLine ("(0 for help)");
            Console.WriteLine ("(1 for blackjack)");
            Console.WriteLine ("(2 for Quarter Game)");
            int n = UIF.PromptInt ("Please enter an integer to choose your game: ");
            games = new List<Casino> ();
            games.Add (new HelpMenu ());
            games.Add (new BlackJack ());
            games.Add (new QuarterGame ());
            while (n != 0 && n != 1 && n != 2) {
                if (n == 0) {
                    Console.WriteLine ("Accessing the Help Menu!" + "\n");// this is where we will print directions/ help menus
                    Console.WriteLine ("MAIN MENU");
                    Console.WriteLine ("(0 for help)");
                    Console.WriteLine ("(1 for blackjack)");
                    Console.WriteLine ("(2 for Quarter Game)");
                }
                if (n == 1) {
                    Console.Clear ();
                    Console.WriteLine ("Playing Blackjack!" + "\n");
                    games [0].PlayGames (); //ensures user will get blackjack
                }
                if (n == 2) {
                    Console.Clear ();
                    Console.WriteLine ("Playing the Quarter Game!" + "\n");
                    games [1].PlayGames (); //ensures user will get quartergame
                }
            
                Console.WriteLine ("Try another game!");
                n = UIF.PromptInt ("Please enter an integer: ");
            }
        }
