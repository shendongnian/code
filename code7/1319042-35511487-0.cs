        public class GenericValidationAttribute: ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var obj = validationContext.ObjectInstance as IBaseObject;
                if(obj == null) return ValidationResult.Success;
                if(obj.content < 0)
                   return new ValidationResult("Content have to be greater than zero!");
                 return ValidationResult.Success;
            }
       }
       
        public class SpecificValidationAttribute: GenericValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var res = base.IsValid(value, validationContext);
                if(res != ValidationResult.Success) return res;
                
                // Do some specific validation
                // ---- 
                return ValidationResult.Success;
            }
        }
