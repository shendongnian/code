	[AttributeUsage(AttributeTargets.Property)]
	class CalculatedByAttribute: Attribute
	{
		public string StaticMethodName {get; private set;}
		public CalculatedByAttribute(string staticMethodName)
		{
			StaticMethodName = staticMethodName;
		}
	}
