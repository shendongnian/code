    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string number = (string)value;
            if (number.Length == 10)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("I will not use DA for this, but there we go...");
            }
        }
