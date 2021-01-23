    public class Ticker 
    {
         private static int _accum;
         public static int Next() 
         {
             return Interlocked.Increment(ref _accum);
         }
    }
