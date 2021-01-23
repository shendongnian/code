    class Program
    {
        static void Main(string[] args)
        {
            int n, sum;
            string input;
            sum = 5000;
            do
            {
                Console.WriteLine("enter number of conversations");
                input = Console.ReadLine();
            } while (int.TryParse(input, out n) == false);
            if (n <= 100)
            {
                sum = sum + n * 5;
            }
            else
            {
                sum += (100 * 5) + (n - 100) * 7;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
