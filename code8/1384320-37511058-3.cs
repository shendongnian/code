	public string ToBinary(byte value)
	{
		string result = "";
		for (int i = 0; i < 8; i++)
		{
			result = value%2 + result;
			value /= 2;
		}
		return result;
	}
	private string ToBinary(byte[] values)
	{
		StringBuilder builder = new StringBuilder();
		int column = 0;
		foreach (byte value in values)
		{
			builder.Append(ToBinary(value) + " ");
			column++;
			if (column == 8)
			{
				builder.AppendLine();
				column = 0;
			}
		}
		return builder.ToString();
	}
