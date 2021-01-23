	public static void Main(string[] args)
	{
		Int16 value1 = 12345;
		Int16 value2 = 31210;
		byte[] bytes = new byte[4];
		Array.Copy(BitConverter.GetBytes(value1), 0, bytes, 0, 2);
		Array.Copy(BitConverter.GetBytes(value2), 0, bytes, 2, 2);
		// store the byte array in your db column.
		// Now let's pretend we're reading the byte array and converting back to our numbers.
		Int16 decodedValue1 = BitConverter.ToInt16(bytes, 0);
		Int16 decodedValue2 = BitConverter.ToInt16(bytes, 2);
		Console.WriteLine(decodedValue1); // prints 12345
		Console.WriteLine(decodedValue2); // prints 31210
	}
