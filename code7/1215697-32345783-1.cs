    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null)
      {
        var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(_dependentProperty);
        var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
        if (otherPropertyValue != null && otherPropertyValue.Equals(_targetValue ))
        {
          return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
      }
      return ValidationResult.Success;
    }
