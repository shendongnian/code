    class DoubleValidatorAttribute : ConfigurationValidatorAttribute
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    
        public DoubleValidatorAttribute(double minValue, double maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    
        public override ConfigurationValidatorBase ValidatorInstance => new DoubleValidator(MinValue, MaxValue);
    }
