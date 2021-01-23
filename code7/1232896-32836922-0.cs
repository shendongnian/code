            int spacelimit = 13, num = 1, n = 5;
            for (int i = 1; i <= n; i++)
            {
                for (int space = spacelimit; space >= i - 3; space--) // HERE, I MADE i-3
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("{0,3:D} ", num++);
                }
                spacelimit = spacelimit - 3;
                Console.WriteLine();
            }
            Console.ReadKey();
