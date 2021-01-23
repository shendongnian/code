	using System;
	using System.Linq;
	using System.Collections.Generic;
	public class Program
	{
		public void Main()
		{
			string input = "suzu";
			string s = @"suzu
	suzu-domestic
	suzu-international
	suzuran
	suzuran-international
	scorpion
	scorpion-default
	yada
	yada-yada";
		
			foreach (var line in ExtractLines(s, input))
				Console.WriteLine(line);	
		}
	
		// works if "-" is your delimiter.
		IEnumerable<string> ExtractLines(string lines, string input)
		{
			return from line in lines.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries) // use to split your string by line
				let cleanLine = line.Contains("-") ? line.Split('-')[0] : line // use only the needed part
				where cleanLine.Equals(input) // check if the output match with the input
				select line; // return the valid line
		}
	}
