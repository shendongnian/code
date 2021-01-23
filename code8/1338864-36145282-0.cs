    public class Utils
    {
       // ...
    
       public static bool isPowerOf2(dynamic x) 
       {
          return (x != 0) && ((x & (~x + 1)) == x);
       }
    }
