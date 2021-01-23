    public struct SplittedMoney
    {
        public readonly int Dollars;
        public readonly decimal Cents;
        public SplittedMoney(int dollars, decimal cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
    }
