    using System;
    using System.Linq;
    using System.Collections.Generic;
					
	public static void Main()
	{
		string[] inputs = {"Third Street Promenade, 1220 3rd St ,Santa Monica, CA 90401","Hi there should"};
		
		List<string> outputs = new List<string>();
		foreach (var input in inputs)
		{
			outputs.AddRange((new String(input.ToCharArray()
    				.Where(c => Char.IsLetterOrDigit(c) || c == ' ')
    				.ToArray()).Split(' ')));
		}
		
		
		foreach (var output in outputs)
			Console.WriteLine(output);
	}
