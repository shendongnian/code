	public FileResult? TryParseFileLine(string fileLine)
	{
		if (string.IsNullOrWhiteSpace(fileLine))
			return null;
			
		...
	}
