            int total = 0;
            int[] values = null;
            int number;
            if(Int32.TryParse(Console.ReadLine(), out number))
            {
                List<int> aux = new List<int>();
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine("Enter {0} value", i);
                    int value;
                    if(Int32.TryParse(Console.ReadLine(), out value))
                    {
                        aux.Add(value);
                        total += value;
                    }                    
                }
                values = aux.ToArray();
            }
            if(values != null)
            {
                if (total > 20)
                {
                    foreach (int value in values)
                    {
                        // code processing
                    }
                }
            }
