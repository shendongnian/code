    public static void SwapPairsL2R( this byte[] a )
    {
      for ( int i = 0 ; i < a.Length ; i+=2 )
      {
        int t  = a[i]   ;
        a[i]   = a[i+1] ;
        a[i+1] = a[i]   ;
        a[i]   = t      ;
       }
       return ;
    }
