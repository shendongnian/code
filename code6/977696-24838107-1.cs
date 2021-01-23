    public static class Extensions
    {
         public int To UnixTime(this DateTime input)
         {
             return (int)input.Subtract(new DateTime(1970,1,1)).TotalSeconds;
         }
    }
