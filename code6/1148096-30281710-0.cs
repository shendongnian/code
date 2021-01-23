            Random numGen = new Random();
            int numOfAttempt = 0;
            for (int i = 0; i < 10; i++)
            {
                int attempt = 0;
                while (attempt != 6)
                {
                    attempt = numGen.Next(1, 7);
                    numOfAttempt++;
                }
            }
            Console.WriteLine("He tried " + numOfAttempt + " times to roll a six.");
            Console.WriteLine("The average number of times it took to get a six was " + numOfAttempt / 10.0);
            Console.ReadKey();
