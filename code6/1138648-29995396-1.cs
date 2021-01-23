	public static void CopyIfDifferent(Object target, Object source)
	{
		foreach (var prop in target.GetType().GetProperties())
		{
			var targetValue = GetPropValue(target, prop.Name);
			var sourceValue = GetPropValue(source, prop.Name);
			if (!targetValue.Equals(sourceValue))
			{
				SetPropertyValue(target, prop.Name, sourceValue);
			}
		}
	}
