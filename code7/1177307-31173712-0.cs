	public virtual Type GetEnumUnderlyingType()
	{
		if (!this.IsEnum)
			throw new ArgumentException(
				Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
		FieldInfo[] fields = this.GetFields(
			BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (fields == null || fields.Length != 1)
			throw new ArgumentException(
				Environment.GetResourceString("Argument_InvalidEnum"), "enumType");
		return fields[0].FieldType;
	}
