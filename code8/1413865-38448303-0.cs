        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string area = (string)validationContext.ObjectType.GetProperty("Area").GetValue(validationContext.ObjectInstance, null);
            string prefix = (string)validationContext.ObjectType.GetProperty("Prefix").GetValue(validationContext.ObjectInstance, null);
            string suffix = (string)validationContext.ObjectType.GetProperty("Suffix").GetValue(validationContext.ObjectInstance, null);
            if ((area.Length + prefix.Length + suffix.Length) == 10)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("I will not use DA for this, but there we go...");
            }
        }
