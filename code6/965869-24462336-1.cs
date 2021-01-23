    public struct SplittedMoney
    {
        public readonly decimal Dollars;
        public readonly decimal Cents;
        public SplittedMoney(decimal dollars, decimal cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
    }
