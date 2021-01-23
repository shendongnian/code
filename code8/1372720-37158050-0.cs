    public static class DateTimeExt
    {
        public static DateTime Flatten(this DateTime self)
        {
            return new DateTime(1, 1, 1, self.Hour, self.Minute, self.Second);
        }
    }
