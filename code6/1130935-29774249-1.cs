	public static T[] Convert<T>(string delimitedValues) where T : struct
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException();
		}
		string[] parts = delimitedValues.Split(',');
		T[] converted = new T[parts.Length];
		for (int i = 0; i < parts.Length; i++)
		{
			if (!Enum.TryParse<T>(parts[i], out converted[i]))
			{
				throw new FormatException(parts[i]);
			}
		}
		return converted;
	}
