    public static class Counter
    {
           private static long hit;
    
           public static void HitCounter()
           {
              hit++;
           }
    
           public static long GetCounter()
           {
              return hit;
           }
    }
