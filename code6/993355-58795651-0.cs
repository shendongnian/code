    static void Main(string[] args)
            {
                int[] numbers = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("Number {0} : ", i + 1);
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                for (int i = 5; i >= 0; i--)
                {
                    Console.Write("{0} ", numbers[i]);
          
                }
                
                Console.ReadLine();
            }
