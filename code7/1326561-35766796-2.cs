    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class IdentifierValidationAttribute : ValidationAttribute
	{
		private readonly ValidationAttribute[] attributes;
		public IdentifierValidationAttribute(int minLength, int maxLength)
		{
			attributes = new ValidationAttribute[] { new EmailAddressAttribute(), new MinLengthAttribute(minLength), new MaxLengthAttribute(maxLength) };
		}
		public override bool IsValid(object value)
		{
			return attributes.All(a => a.IsValid(value));
		}
	}
