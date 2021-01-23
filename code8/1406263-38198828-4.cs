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
		/// <summary>
		/// Implicit conversion from double to MoneyAmount. 
		/// Implicit: No cast operator is required.
		/// </summary>
		public static implicit operator MoneyAmount(double value)
		{
			return new MoneyAmount(value);
		}
		/// <summary>
		/// Explicit conversion from MoneyAmount to double. 
		/// Explicit: A cast operator is required.
		/// </summary>
		public static explicit operator double(MoneyAmount value)
		{
			return value._value;
		}
		/// <summary>
		/// Explicit conversion from MoneyAmount to int. 
		/// Explicit: A cast operator is required.
		/// </summary>
		public static explicit operator MoneyAmount(int value)
		{
			return new MoneyAmount(value);
		}
		/// <summary>
		/// Explicit conversion from MoneyAmount to int. 
		/// Explicit: A cast operator is required.
		/// </summary>
		public static explicit operator int(MoneyAmount value)
		{
			return (int)value._value;
		}
        // All other members here...
    }
