            int[] GameScores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Please enter an index between 0 and 9");
            int gamescores = int.Parse(Console.ReadLine());
            if (GameScores.Contains(gamescores))
            {
                Console.WriteLine("score exists");
            }
            else
            {
                Console.WriteLine("No such score exists");
            }
