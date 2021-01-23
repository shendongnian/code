    class SqrtPrime
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter number: ");
                int number = int.Parse(Console.ReadLine());
    
                Console.WriteLine("Square Root is: " + Math.Sqrt(number) + "\n");
                Console.WriteLine("Next Prime is " + CheckPrimeUpwards(number) + "\n");
                Console.WriteLine("Last Prime was " + CheckPrimeDownwards(number) + "\n");
    
                Console.ReadLine();
            }
    
            static int CheckPrimeDownwards(int number)
            {
                int result = number;
    
                while(!IsNumberAPrime(result))
                {
                    result--;
                }
    
                return result;
            }
    
            static int CheckPrimeUpwards(int number)
            {
                int result = number;
    
                while (!IsNumberAPrime(result))
                {
                    result++;
                }
    
                return result;
            }
    
            public static bool IsNumberAPrime(int number)
            {
                int boundary = (int)Math.Floor(Math.Sqrt(number));
    
                if (number < 2)
                {
                    return false;
                }
    
                if (number == 2)
                {
                    return true;
                }
    
                for (int i = 2; i <= boundary; ++i)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
    
                return true;
            }
        }
