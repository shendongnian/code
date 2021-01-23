	private static int? ParseStringContainingNumber(string input)
	{
        if (String.IsNullOrEmpty(input))
		{
			return null;
		}
		var numbersInInput = new String(input.Where(Char.IsDigit).ToArray());
		if (String.IsNullOrEmpty(numbersInInput))
		{
			return null;
		}
		
		int output;
		
		if (!Int32.TryParse(numbersInInput, out output))
		{
			return null;
		}
		
		return output;
	}
