        static int GetPlayers(int max = 10) {
            for (;;) {
                Console.Write("Number of players: ");
                int players;
                if (int.TryParse(Console.ReadLine(), out players)) {
                    if (players > 0 && players <= max) return players;
                }
                Console.WriteLine("  Oops, please type a number between 1 and " + max.ToString());
            }
        }
