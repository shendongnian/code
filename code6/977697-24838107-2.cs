    public static class Extensions
    {
         public static  double ToUnixTime(this DateTime input)
         {
             return input.Subtract(new DateTime(1970,1,1)).TotalSeconds;
         }
    }
