	class Program {
		static void Main(string[] args) {
			int i = 0;
			while (i < 20) {
				Console.Write(++i);
				Console.Write(++i);
				Console.Write(++i);
				Console.Write(++i);
				Console.WriteLine(++i);
			}
			Console.ReadKey();
		}
	}
