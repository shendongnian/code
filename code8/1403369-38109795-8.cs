    public static class DateTimeExtensions
    {
      public static DateTime ParseToDateTime(this string date, string time = null)
      {
         return string.IsNullOrEmpty(withTime) ? DateTime.Parse(date) : DateTime.Parse($"{date} {time}");
      }
    }
