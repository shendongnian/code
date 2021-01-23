    public struct MoneyAmount
    {
        const int N = 4;
        private readonly decimal _value;
        public MoneyAmount(decimal value)
        {
            _value = Math.Round(value, N);
        }
        // All other members here...
    }
