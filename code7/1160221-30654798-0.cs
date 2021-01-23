        static void Main(string[] args)
        {
            int i;
            Console.Write(" Enter a number: ");
            if (Int32.TryParse(Console.ReadLine(), out i))
            {
                if (i % 2 == 0)
                {
                    Console.Write(" The number is even");
                }
                else
                {
                    Console.Write(" The number is odd");
                }
            }
            else
            {
                Console.Write(" You have to enter a number I can parse into an integer, dummy!");
            }
        }
