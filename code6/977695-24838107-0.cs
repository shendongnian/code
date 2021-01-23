    public static class Extensions
    {
         public double To UnixTime(this DateTime input)
         {
             return input.Subtract(new DateTime(1970,1,1)).TotalSeconds;
         }
    }
