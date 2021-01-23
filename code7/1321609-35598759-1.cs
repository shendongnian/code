     static void Main(string[] args)
        {
            Calc();
        }
        static void Calc()
        {
            int input1, input2;
            Console.WriteLine("Enter First Digit");
            if (!Int32.TryParse(Console.ReadLine(), out input1))
            {
                Console.WriteLine("Wrong Number!");
                return;
            }
            Console.WriteLine("Enter Second Digit");
            if (!Int32.TryParse(Console.ReadLine(), out input2))
            {
                Console.WriteLine("Wrong Number!");
                return;
            }
            Console.WriteLine(string.Format("Total = {0}" , input1 + input2));
            Console.ReadLine();
        }
            
