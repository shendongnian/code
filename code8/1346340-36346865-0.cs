    class Program
    {
        static void Main(string[] args)
        {
            // Take in the start point and the end point
            Console.WriteLine("Starting Number:");
            Int32 numberStart = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ending Number:");
            Int32 numberEnd = Convert.ToInt32(Console.ReadLine());
            // Loop from the first number to the last number, and check if each one is prime
            for(int number = numberStart; number < numberEnd; number++)
            {
                Console.WriteLine(number + " is prime?");
                Console.WriteLine(isPrime(number) + "\n");
            }
            Console.ReadLine();
        }
        // Function for checking if a given number is prime.
        public static bool isPrime(int number)
        {
            int boundary = (int) Math.Floor(Math.Sqrt(number));
            if (number == 1) return false;
            if (number == 2) return true;
            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
