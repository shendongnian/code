            foreach (var zero in myList)
            {
                if (zero == 0)
                {
                    zeroes += 1;
                }
            }
    
            Console.WriteLine(zeroes);
            Console.ReadKey();
    
    
            Console.ReadKey();
        }
    
        static List<int> ATM(int value)
        {
            List<int> exchangeCoins = new List<int>();
    
            if (value != 0)
            {                                 // 7 3 2 1
                exchangeCoins.Add(value / 2); // 3 1 1 0
                exchangeCoins.Add(value / 3); // 2 1 0 0
                exchangeCoins.Add(value / 4); // 1 0 0 0
            }
           else
            {
                throw new Exception("Value can't be zero!");
            }
    
            return exchangeCoins;
    
        }
    }
