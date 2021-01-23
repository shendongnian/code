      public static long Power(long A, ulong n)
        {
            long result = 1;    // if n==0,A^n==1
           
            if (n>0)
            {
                do
                {
                    result *= A;
                    n--;
                } while (n>0);
            }            
            return result;
        }
