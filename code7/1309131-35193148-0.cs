    static int nCalc()
    {
      int n;
      for(n=1; n<=200; n++)
      {
    
        if (n == 1)
        {
          fileOut.WriteLine("{0}", n);
        }
        else if (n % 2 == 0)
        {
          n = 3 * n + 1;
        }
        else
        {
          n = n / 2;
        }
       
    
      }
     return n;
    }
