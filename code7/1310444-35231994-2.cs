    public static class StringExtensions
    {
        public static DateTime LastDayOfMonth(this DateTime self)
        {
            return new DateTime(self.Year, self.Month, DateTime.DaysInMonth(self.Year, self.Month));
        }
    
        public static DateTime? LastDayOfMonth(this string self)
        {
            DateTime dt;
            if (!DateTime.TryParse(self, out dt))
                return null;
    
            return dt.LastDayOfMonth();
        }
    }
