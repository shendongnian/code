    public class NotEmptyStringValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string s = value as string;
			if (String.IsNullOrEmpty(s))
			{
				return new ValidationResult(false, "Field cannot be empty.");
			}
			return ValidationResult.ValidResult;
		}
	}
