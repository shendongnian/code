    class FixedLengthAttribute : Attribute 
    { 
        public int Length { get; set; }
    }
    public override void Apply(ConventionPrimitivePropertyConfiguration configuration,
            FixedLengthAttribute attribute)
    {
        configuration.IsFixedLength();
        configuration.HasMaxLength(attribute.Length);
    }
    class MyEntity
    {
        [Key, FixedLength(Length=10)]
        public string MyStringProperty { get; set; }
    }
