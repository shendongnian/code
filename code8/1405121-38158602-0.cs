	string a = "xx";
	string b = "x" + "x";
	string c = string.Join("", new[] { "x", "x" }); //no interning here
	Console.WriteLine((object)a == (object)b); // True
	Console.WriteLine(a == b); // True
	Console.WriteLine((object)a == c); //False
	Console.WriteLine(a == c); // True
