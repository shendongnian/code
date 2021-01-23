	using System; 
	using System.Collections.Generic; 
	using System.Linq; 
	using System.Text; 
	 
	// Specifically adding the Delimon.Win32.IO Library to use in the current Code Page 
	using Delimon.Win32.IO; 
	 
	namespace ConsoleApplication1 
	{ 
		class Program 
		{ 
			static void Main(string[] args) 
			{ 
				string[] files = Directory.GetFiles(@"c:\temp"); 
				foreach (string file in files) 
				{ 
					Console.WriteLine(file); 
				} 
				Console.ReadLine(); 
			} 
		} 
	}
