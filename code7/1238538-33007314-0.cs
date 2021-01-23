    public class DescriptionWithValueAttribute : DescriptionAttribute
    {
        public Decimal Value { get; private set; }
    
        public DescriptionWithValueAttribute(String description, Double value)
            : base(description)
        {
            Value = Convert.ToDecimal(value);
        }
    }
