    public class MyAttribue : ValidationAttribute {
        protected readonly string _fieldName;
    
        public MyAttribue(string fldName) {
          _fieldName = fldName;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
          if (validationContext == null) {
            return ValidationResult.Success;
          }
          ErrorMessage = string.Empty;
    
          if (validationContext.ObjectInstance != null) {
            // do whathever validation is required using _fieldName...
          }
          //
          if (!string.IsNullOrWhiteSpace(ErrorMessage)) {
            return new ValidationResult(ErrorMessage);
          }
          return ValidationResult.Success;
        }
      }
