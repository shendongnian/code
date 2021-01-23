    static void Main() 
    {
       for(int n=1;n<=200;n++)
       {
           fileOut.WriteLine("{0}",Calc(n));
       }
    }
    static int Calc(int n)
    {
        int result;
        if (n == 1)
        {
            result = 0;
        }
        else if (n % 2 == 0)
        {
          result = 3 * n + 1;
        }
        else
        {
          result = n / 2;
        }
        return result;
    }
