    sealed class DayOfWeek
    {
        public static readonly DayOfWeek Monday = new DayOfWeek(0);
        public static readonly DayOfWeek Tuesday = new DayOfWeek(1);
        public static readonly DayOfWeek Wednesday = new DayOfWeek(2);
        public static readonly DayOfWeek Thursday = new DayOfWeek(3);
        public static readonly DayOfWeek Friday = new DayOfWeek(4);
        public static readonly DayOfWeek Saturday = new DayOfWeek(5);
        public static readonly DayOfWeek Sunday = new DayOfWeek(6);
        private readonly int _value;
        private DayOfWeek(int value) 
        {
            _value = value;
        }
        // Make sure you override Equals, GetHashCode, operator== and operator!=
    }
