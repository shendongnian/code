	for (int index = 0; index < string1.Length; index += 5)
	{
		string subString = new String(string1.Skip(index).Take(5).ToArray());
		Console.WriteLine(subString);
	}
