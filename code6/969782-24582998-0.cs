	public static void Main()
	{
      string str = "Hello# , how are you?";
      string remove = Regex.Replace(str, @"[\W_]$", "");
      string result = Regex.Replace(remove, @"[\W_]+", "-");
      Console.WriteLine(result);
      Console.ReadLine();
    }
