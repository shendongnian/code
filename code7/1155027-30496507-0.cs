    [AttributeUsage(AttributeTargets.Property)]
    public class EqualsToTextAttribute : ValidationAttribute
    {
        #region Instance Fields
        private readonly string[] textToCompare;
        #endregion
        #region Constructors
        public EqualsToTextAttribute(string[] textToCompare)
        {
            this.textToCompare = textToCompare;
        }
        #endregion
        #region Protected Methods
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
            if (this.textToCompare.Any(text => string.Equals(value.ToString(), text, StringComparison.OrdinalIgnoreCase)))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
        #endregion
    }
