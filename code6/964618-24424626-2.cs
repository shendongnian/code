    private static void Main(string[] args)
	{
		string str1 = "hello world";
		string str2 = "<p><div>hello</div> world <div>some text</div></p>";
		Console.WriteLine("Original: " + str1);
		Console.WriteLine("Edited value: " + ReplaceHtmlInnerText(str1));
		Console.WriteLine("Original: " + str2);
		Console.WriteLine("Edited value: " + ReplaceHtmlInnerText(str2));
		Console.Read();
	}
