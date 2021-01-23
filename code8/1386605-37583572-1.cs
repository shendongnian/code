    var value = values[name];
	if (value is DateTime)
	{
		var date = (DateTime)value;
		if (date < SqlDateTime.MinValue.Value)
		{
			values[name] = SqlDateTime.MinValue.Value;
		}
		else if (date > SqlDateTime.MaxValue.Value)
		{
			values[name] = SqlDateTime.MaxValue.Value;
		}
	}
