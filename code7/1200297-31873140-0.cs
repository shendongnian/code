    class Program
	{
		static void Main(string[] args)
		{
			var di = Directory.CreateDirectory("MyFolder");
			File.WriteAllText(Path.Combine(di.FullName, "File.txt"), "This will be written to the file");
		}
	}
