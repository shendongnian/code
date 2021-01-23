    public class CusomValidatorForFeaturettes: ValidationAttribute
    {
        private readonly string _OtherProperty;
        public CusomValidatorForFeaturettes(string otherProperty): base("NOT OK")
        {
            _OtherProperty = otherProperty;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the dependent property 
            var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(_OtherProperty);
            // Get the value of the dependent property 
            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
            ......
