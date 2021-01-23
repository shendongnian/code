    static void Main(string[] args)
            {          
                for (int i = 001; i <= 2015; i++)
                {
                    if (i % 4 == 0)
                    {                    
                        if (DateTime.DaysInMonth(i, 2) != 29)
                        {
                            Console.WriteLine("Days {0} in a month feb Year {1}..", DateTime.DaysInMonth(i, 2), i);
                        }
                    }
                }
                Console.ReadLine();
            }
