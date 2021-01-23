	string a = "xx";
	string b = "x" + "x"; //interning here
	string c = string.Join("", new[] { "x", "x" }); //no interning here
	Console.WriteLine((object)a == (object)b); // True. reference check
	Console.WriteLine(a == b); // True. value check
	Console.WriteLine((object)a == c); //False. reference check. described below
	Console.WriteLine(a == c); // True. value check
