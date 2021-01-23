    public sealed class Temperature(decimal value, Unit unit)
    {
        public decimal Value { get; } = value;
        public Unit    Unit  { get; } = unit;
    }
