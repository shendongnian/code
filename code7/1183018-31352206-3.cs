    class Program
    {
      public static int Version1(int n)
      {
        int cnt = 0;
        for ( int i = 0 ; i < n ; i+=2 )
        {
          ++cnt;
        }
        return cnt;
      }
      
      public static int Version2(int n)
      {
        int cnt = 0;
        for ( int i = 0 ; i < n ; ++i )
        {
          if ( i % 2 == 0 )
          {
            ++cnt;
          }
        }
        return cnt;
      }
      
      public static int Version3(int n)
      {
        int cnt = 0;
        for ( int i = 0 ; i < n ; ++i )
        {
          if ( 0 == (i & 1) )
          {
            ++cnt;
          }
        }
        return cnt;
      }
      
      private static void Main(string[] args)
      {
        int n = 500000000;
        Stopwatch timer = new Stopwatch();
        
        timer.Start();
        Version1( n );
        timer.Stop();
        Console.WriteLine( "{0:c} -- Version #1 (incrementing by 2)" , timer.Elapsed ) ;
        
        timer.Restart();
        Version2(n);
        timer.Stop();
        Console.WriteLine( "{0:c} -- Version #2 (incrementing by 1 with modulo test)" , timer.Elapsed ) ;
        
        timer.Restart();
        Version3(n);
        timer.Stop();
        Console.WriteLine( "{0:c} -- Version #3 (incrementing by 1 with bit twiddling)" , timer.Elapsed ) ;
        
        return;
        
      }
      
    }
