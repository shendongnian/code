    class Program
    {
        static int computeProd1(int num1, int num2)
        {
            return (num1 * num2);
        }
        public static void Main(string[] args)
        {
            int? first = null, second = null;
            int first_i = 0, second_i = 0;
            while (!first.HasValue)
            {
                Console.WriteLine("enter first number");
                if (int.TryParse(Console.ReadLine(), out first_i))
                {
                    first = first_i;
                }
            }
            while (!second.HasValue)
            {
                Console.WriteLine("enter second number");
                if (int.TryParse(Console.ReadLine(), out second_i))
                {
                    second = first_i;
                }
            }
            int product = computeProd1(first_i, second_i);
            Console.WriteLine("Their product is:\t" + product);
            Console.Read();
        }
    }
