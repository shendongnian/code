    [AttributeUsage(AttributeTargets.Property)]
	public sealed class EmailAddressListAttribute : ValidationAttribute
	{
		private const string defaultError = "'{0}' contains an invalid email address.";
		public EmailAddressListAttribute()
			: base(defaultError) //
		{
		}
		public override bool IsValid(object value)
		{
			EmailAddressAttribute emailAttribute = new EmailAddressAttribute();
			IList<string> list = value as IList<string>;
			return (list != null && list.All(email => emailAttribute.IsValid(email)));
		}
		public override string FormatErrorMessage(string name)
		{
			return String.Format(this.ErrorMessageString, name);
		}
	}
