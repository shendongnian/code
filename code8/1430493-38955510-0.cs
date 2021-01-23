	public static decimal Add(this decimal a, decimal b)
	{
		var result = a + b;
		
		if (b != 0 && a == result)
			throw new InvalidOperationException("Precision loss!");
		
		return result;
	}
