    class Program
    {
        static void Main(string[] args)
        {
            int numberStart;
            int numberEnd;
            // Take in the start point and the end point
            Console.WriteLine("Starting Number:");
            if(!int.TryParse(Console.ReadLine(), out numberStart)){
                Console.WriteLine("Your input is invalid.");
            }
            Console.WriteLine("Ending Number:");
            if (!int.TryParse(Console.ReadLine(), out numberEnd))
            {
                Console.WriteLine("Your input is invalid.");
            }
            // Loop from the first number to the last number, and check if each one is prime
            for (int number = numberStart; number < numberEnd; number++)
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
