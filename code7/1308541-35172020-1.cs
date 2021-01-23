     public static DateTime From(this DateTime value)
     {
         return new DateTime((value.Year, value.Month, value.Day);
     }
     public static DateTime To(this DateTime value)
     {
         return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
     }
