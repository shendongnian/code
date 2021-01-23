	public string ToBase64String(string text)
	{
		byte[] data = Encoding.UTF8.GetBytes(text);
		return Convert.ToBase64String(data);
	}
