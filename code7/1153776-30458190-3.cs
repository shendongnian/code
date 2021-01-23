     public static class DateTimeExtensions
     {
         public static DateTime AddBusinessDays(this DateTime date, int days)
         {
             double sign = Convert.ToDouble(Math.Sign(days));
             int unsignedDays = Math.Sign(days) * days;
             for (int i = 0; i < unsignedDays; i++)
             {
                 do
                 {
                     date = date.AddDays(sign);
                 }
                 while (date.DayOfWeek == DayOfWeek.Saturday || 
                    date.DayOfWeek == DayOfWeek.Sunday);
             }
             return date;
          }
     }
