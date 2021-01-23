	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var propertyTestedInfo = validationContext.ObjectType.GetProperty(this._DependentProperty);
		if (propertyTestedInfo == null)
		{
			return new ValidationResult(string.Format("{0} needs to be exist in this object.", this._DependentProperty));
		}
		var dependendValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
		if (dependendValue == null)
		{
			return new ValidationResult(string.Format("{0} needs to be populated.", this._DependentProperty));
		}
		if (dependendValue.Equals(this._TargetValue))
		{
			var fieldValue = validationContext.ObjectType.GetProperty(validationContext.MemberName).GetValue(validationContext.ObjectInstance, null);
			if (fieldValue != null)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult(string.Format("{0} cannot be null", validationContext.MemberName));
			}
		}
		else
		{
			// Must be ignored
			return ValidationResult.Success;
		}
	}
