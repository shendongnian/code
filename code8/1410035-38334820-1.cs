    public override bool IsValid(object value)
	{
		return IsValid(value != null ? value : null)
	}
	public override ValidationResult IsValid(object value, ValidationContext context = null)
	{
		bool isValid = false;
		if(typeof(value) == Nullable<int>)
		{
			int? temp = value as Nullable<int>;
			
			if(temp.HasVaue > minValue && temp.HasValue < maxValue)
			{
				return ValidationResult.Success;
			}
			
			return new ValidatonResult(errorMessage);
		}
	}
