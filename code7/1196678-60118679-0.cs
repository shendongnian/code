	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
	public sealed class EnumDataTypeArrayAttribute : DataTypeAttribute
	{
		public EnumDataTypeArrayAttribute(Type enumType)
			: base("Enumeration")
		{
			if (enumType == null)
			{
				throw new InvalidOperationException("Type cannot be null");
			}
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException("Type must be an enum");
			}
			this.EnumType = enumType;
		}
		public override bool IsValid(object value)
		{
			if (value == null) return true;
			var at = value.GetType();
			if (!at.IsArray) return false;
			var t = at.GetElementType();
			if (t != this.EnumType) return false;
			foreach (var v in value as Array)
			{
				if (!Enum.IsDefined(this.EnumType, v))
				{
					return false;
				}
			}
			return true;
		}
		public Type EnumType
		{
			get;
			private set;
		}
	}
