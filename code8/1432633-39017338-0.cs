    var s = "The%20%20%20%20%20%20%20%20%20%20Park";
	var regex = new Regex("(%20)+", RegexOptions.ExplicitCapture);
	var output = regex.Replace(s, "-");
	Console.WriteLine(output);           // => The-Park
		
	output  = string.Join("-", s.Split(new[] {"%20"}, StringSplitOptions.RemoveEmptyEntries));
	Console.WriteLine(output);           // => The-Park
