    struct DayOfWeek
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
        public bool Equals(DayOfWeek other)
        {
            return _value == other._value;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is DayOfWeek && Equals((DayOfWeek)obj);
        }
        public override int GetHashCode()
        {
            return _value;
        }
        public static bool operator ==(DayOfWeek op1, DayOfWeek op2)
        {
            return op1.Equals(op2);
        }
        public static bool operator !=(DayOfWeek op1, DayOfWeek op2)
        {
            return !(op1 == op2);
        }
    }
