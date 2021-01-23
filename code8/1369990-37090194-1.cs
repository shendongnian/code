    public static class SystemTime
    {
        private static DateTime _date;
        public static DateTime Now => _date != DateTime.MinValue ? _date : DateTime.Now;
        public static DateTime Today => _date == DateTime.MinValue ? DateTime.Today : _date.Date;
        [Conditional("DEBUG")]
        public static void Set(DateTime date)
        {
            _date = date;
        }
        public static void Reset()
        {
            _date = DateTime.MinValue;
        }
    }
