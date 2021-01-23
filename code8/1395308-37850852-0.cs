	static void Main(string[] args)
	{
		Compile("abc.exe", "Abc");
		Compile("bcd.exe", "Bcd");
	}
	static void Compile(string fileName, string param1)
	{
		var code = "using System;"
			+ "public class Program {"
			+ "    public static void Main(string[] args)"
			+ "    {"
			+ "        Console.WriteLine(\"" + param1 + "\");"
			+ "    }"
			+ "}";
		var provider = new CSharpCodeProvider();
		var options = new CompilerParameters();
		options.GenerateExecutable = true;
		options.OutputAssembly = fileName;
		options.MainClass = "Program";
		provider.CompileAssemblyFromSource(options, code);
	}
