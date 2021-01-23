    using System.Numerics;
  
    //...
    private static BigInteger Factorial(int number)
    {
        BigInteger n = 1;
        for (int i = 1; i < number; i++)
        {
            n *= i;
        }
        return n;
    }
