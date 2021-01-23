           int[] GameScores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Please enter an index between 0 and 9");
            int gamescores = int.Parse(Console.ReadLine());
            if (gamescores >= 0 && gamescores<=9)
            {
                for (int i = 0; i < GameScores.Length; i++)
                {
                    GameScores[i] = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("Number not valid");
            }
