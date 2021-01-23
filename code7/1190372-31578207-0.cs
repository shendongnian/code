    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give some numbers");
            int i = 0, j = 0;
            string n = Console.ReadLine();
            string[] numbers = n.Split(' ');
            int s = 0;
            for (i = 0; i < numbers.Length; i++)
            {
                s += int.Parse(numbers[i]);
            }
            Console.Write("the sum of your numbers is: {0} ", s);
            Console.ReadLine();
        }
    }
