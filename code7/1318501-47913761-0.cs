    class Program
    {
      static bool IsPrime(int i)
      {
        for (long n = 2; n < i; n++)
        {
          if (i % n == 0)
            return false;
        }
        return true;
      }
      static void Main(string[] args)
      {
        long number = 600851475143;
        for (long i = 3; i <= number; i++)
        {
          if (IsPrime(i))
            Console.WriteLine(i);
        }
        Console.ReadKey();
      }
    }
