    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CompareEnhancedAttribute : CompareAttribute
    {
        public bool AllowEmptyStrings { get; set; }
        public CompareEnhancedAttribute(string otherProperty)
            : base(otherProperty)
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowEmptyStrings && string.IsNullOrEmpty(value?.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return base.IsValid(value, validationContext);
            }
        }
    }
