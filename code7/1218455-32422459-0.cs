	int parsedValue = 0;
	if (m2[0].Success)
	{
		var value = m2[0].Groups[1].Captures[0].Value;
		if (!string.IsNullOrWhiteSpace(value))
		{
			if (int.TryParse(value, out parsedValue))
			{
				// do something with parsedValue, or with the fact that the value exists and is an integer
			}
		}
	}
