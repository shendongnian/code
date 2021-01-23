    namespace Extensions{
    public static class DateExtensions
    {
        public static string GetDifferenceTillNow(this DateTimeOffset? datetimeoffset) {
            DateTimeOffset? creationTime = datetimeoffset;
            DateTimeOffset rightnow = DateTimeOffset.Now;
            DateTimeOffset somewhen = creationTime ?? rightnow;
            TimeSpan difference = rightnow.Subtract(somewhen);
            return difference.Days.ToString() +" days & " +  difference.Hours.ToString() + " hours ago";
        }
      }
    }
