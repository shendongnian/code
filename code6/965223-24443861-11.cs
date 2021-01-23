    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var foo = Console.ReadLine();
            if (int.TryParse(foo, out int number1)) {
                Console.WriteLine($"{number1} is a number");
            }
            else
            {
                Console.WriteLine($"{foo} is not a number");
            }
            Console.WriteLine($"The value of the variable {nameof(number1)} is {number1}");
            Console.ReadLine();
        }
    }
