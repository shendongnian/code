    public class RequiredIfISaySo : ValidationAttribute//, IClientValidatable
    {
        public RequiredIfISaySo(int RequiredReason)
        {
            _reqReason = RequiredReason;
        }
        private RequiredAttribute _reqAttribute = new RequiredAttribute();
        private int _reqReason;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_reqReason == 1)
            { 
                if (!_reqAttribute.IsValid(value))
                {
                    return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }
    }
