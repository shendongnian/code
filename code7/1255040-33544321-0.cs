            static void Main(string[] args)
        {
            int n;
            string input;
            Console.WriteLine("Please enter a number to work out the factorial");
            input = Console.ReadLine();
            bool test = int.TryParse(input, out n);
            int factorial = fact(n);
            Console.WriteLine("{0} factorial is {1}", n, factorial);
            Console.ReadLine();
        }
        public static int fact(int y)
        {
            if (y <= 1)
            {
                return 1;
            }
            else
            {
                return y * fact(y - 1);
            }
