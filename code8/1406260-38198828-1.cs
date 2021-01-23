    public struct MoneyAmount
    {
        const int N = 4;
        private readonly double _value;
        public MoneyAmount(double value)
        {
            _value = Math.Round(value, N);
        }
        // Example of one member of double:
        public static MoneyAmount operator *(MoneyAmount d1, MoneyAmount d2) 
        {
            return new MoneyAmount(d1._value * d2._value);
        }
        // All other members here...
    }
