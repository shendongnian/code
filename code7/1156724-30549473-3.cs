	public static void Main()
	{
		byte[] buf = new byte[] { 0xF0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
		byte result = 0;
		foreach(var b in buf.Reverse())
		{
			result <<= 1;
			if(b == 0xFF) result |= 1;
		}
		Console.WriteLine(result);
	}
