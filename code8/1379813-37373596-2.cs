    using System;
    using System.Linq;
    using System.Collections.Generic;
					
	public static void Main()
	{
		string[] inputs = {"Third Street Promenade, 1220 3rd St ,Santa Monica, CA 90401","Hi there should"};
		
		Func<string, string> clean = x => new String(x.Where(c => Char.IsLetterOrDigit(c) || c == ' ').ToArray());
		var outputs = inputs.SelectMany(input => clean(input).Split(' '));
				
		foreach (var output in outputs)
			Console.WriteLine(output);
	}
