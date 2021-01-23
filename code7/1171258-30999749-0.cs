        static void Main(string[] args)
        {
            string name;
            int age;
            Console.WriteLine("How old are you?");
            string input = Console.ReadLine();
            {
                if (int.TryParse(input, out age))
                {
                    {
                        agedetermine();
                    }
                }
                else
                {
                    Console.WriteLine("Give me an actual answer...");
                    while (!int.TryParse(Console.ReadLine(), out age))
                        Console.WriteLine("I don't have all day.");
                    agedetermine();
                    
                }
            }
        }
