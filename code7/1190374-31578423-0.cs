    static void Main(string[] args)
            {
                Console.WriteLine("Give some numbers");
                int i = 0;
                string n = Console.ReadLine();
                string[] numbers = n.Split(' ');
                if (numbers != null && numbers.Length > 0)
                {
                    int[] array = new int[numbers.Length];
                    int s = 0;
                    for (i = 0; i < numbers.Length; i++)
                    {
                         // Check if numbers[i] values is integer then add to array for some
                         int number;
                         bool result = Int32.TryParse(numbers[i], out number);
                         if (result)
                         {
                             array[i] = number;
                         }
                    }
                    s = Sum(array);
                    Console.Write("The sum of your numbers is: {0} ", s);
                }
                Console.Read();
            }
