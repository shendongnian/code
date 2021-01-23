	public void properColumnValue(object columnValue)
	{
		Type[] number_types = new[] {typeof (int), typeof (decimal), typeof (long)};
		if (number_types.Contains(columnValue.GetType()))
		{
			// convert to long, or whatever you need it to be:
			long value = Convert.ToInt64(columnValue);
			//... do something with the value
		}
	}
