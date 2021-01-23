	string a = "xx";
	string b = "x" + "x"; // String interning here
	string c = string.Join("", new[] { "x", "x" }); // No interning here because it is evaluated at runtime
	Console.WriteLine((object)a == (object)b); // True. Reference check
	Console.WriteLine(a == b); // True. Value check
	Console.WriteLine((object)a == c); //False. Reference check. Described below
	Console.WriteLine(a == c); // True. Value check
