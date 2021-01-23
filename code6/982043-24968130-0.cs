	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class ValidationRuleAttribute : Attribute
	{
		public IValidationRule ValidationRule { get; private set; }
		public ValidationRuleAttribute(RuleType type, params object[] parms)
		{
			if (type == RuleType.NotNull)
			{
				if (parms.Length != 0)
					throw new ArgumentException("RuleType.NotNull requires 0 parameters", "parms");
				ValidationRule = new NotNullValidation();
			}
			if (type == RuleType.StringMinLength)
			{
				if (parms.Length != 1)
					throw new ArgumentException("RuleType.StringMinLength requires 1 parameter", "parms");
				if (!(parms[0] is int))
					throw new ArgumentException("RuleType.StringMinLength requires an integer", "parms");
				ValidationRule = new StringLengthValidation((int)parms[0]);
			}
		}
	}
