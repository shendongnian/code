	class Program {
		static void Main(string[] args) {
			Console.WriteLine("This is the program");
			if (args == null || args.Length == 0) {
				Console.WriteLine("This has no argument");
				Console.ReadKey();
				return;
			}
			Console.WriteLine("This has {0} arguments, the arguments are: ", args.Length);
			for (int i = 0; i < args.Length; ++i)
				Console.WriteLine(args[i]);
			Console.ReadKey();
		}
	}
