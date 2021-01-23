    public enum Unit
    {
        Micro = -6, Milli = -3, Centi = -2, Deci = -1,
        One /* Don't really like this name */, Deca, Hecto, Kilo, Mega = 6, Giga = 9
    }
    public struct Quantity
    {
        public decimal Value { get; private set; }
        public Unit Unit { get; private set; }
        public Quantity(decimal value, Unit unit) : 
            this()
        {
            Value = value;
            Unit = unit;
        }
        public decimal OneValue /* This one either */
        {
            get
            {
                return Value * (decimal)Math.Pow(10, (int)Unit);
            }
        }
    }
