    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
      public class Numeric : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
          if (value == null) {
            return ValidationResult.Success;
          }
          double result;
          var isNumeric = double.TryParse(value.ToString(), out result);
          return !isNumeric ? new ValidationResult(this.ErrorMessage) : ValidationResult.Success;
        }
      }
