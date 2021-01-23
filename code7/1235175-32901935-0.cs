    public class EnumValue : Attribute
    {
        public Decimal Value { get; private set; }
        public EnumValue(Decimal value)
        {
            this.Value = value;
        }
    }
