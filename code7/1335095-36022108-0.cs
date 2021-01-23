            int total = 0;
            double avg;
            string inValue;
            int[] score = new int[8];
            // prompt user for initial values
            for (int i = 0; i < score.Length; i++)
            {
                Console.Write("Please enter homework score [0 to 10] (-99 to exit): \n", i + 0);
                inValue = Console.ReadLine();
                if (int.TryParse(inValue, out score[i]))
                {
                    if (score[i] == 99)
                    { Environment.Exit(0); }
                    bool between0and10 = score[i] <= 10 && score[i] >= 0;
                    if (!between0and10)
                    { Console.WriteLine("Integer entered, {0}, is not between 0 and 10."); }
                }
                else
                { Console.WriteLine("\n\tInvalid data - re - enter homework score: "); }
            }
