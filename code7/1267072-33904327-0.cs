    public static void Main()
	{
		Console.WriteLine("Hello World");
		SaveMessageIntoBinaryFile(new []{"00", "110"}, new char[]{'a', 'b'}, "aab", "output.txt", "");
	}
	
	static void SaveMessageIntoBinaryFile (string[] codes, char[] symbolSet, string sampleText, string fileName, string path)
	{
		using(var writer = new StreamWriter(File.Open(Path.Combine(path, fileName), FileMode.Create)))
		{
			foreach(var symbol in sampleText)
			{
				var codeIndex = Array.IndexOf<char>(symbolSet, symbol);
				writer.Write(codes[codeIndex]);
				Console.Write(codes[codeIndex] + "\t");
			}
		}
	}
