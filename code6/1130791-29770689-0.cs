    private static BigInteger factorial(int n)
    {
         BigInteger fact = 1;
         for (int i = 1; i <= n; i++)
         {
            fact *= i;
         }
         return fact;
     }
    
     // output: 9694845
