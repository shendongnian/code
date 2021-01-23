     int i;
            int i2;
            int j;
            int j2;
            for (i = 7; i > 1; i--)
            {
                for (j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (i = 0; i < 1; i++)
            {
                Console.WriteLine("C");
            }
            Console.WriteLine();
            for (i2 = 0; i2 < 9; i2++)
            {
                for (j2 = 0; j2 < i2; j2++)
                {
                    
                    if (i2 == 7)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
          
            Console.ReadLine();
        }
