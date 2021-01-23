        public void RollDice(int NumberOfDice)
        {
            Random numgen = new Random();
            for (int roll = 0; roll <= 10; roll++)
            {
                for (int i = 0; i < NumberOfDice; i++)
                {
                    Console.WriteLine(numgen.Next(1, 7) + "\t" + numgen.Next(1, 7));
                }
            }
            Console.ReadLine();
        }
