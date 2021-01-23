		string a = "aaa", b="bbbbb";
		
		Console.WriteLine(a);
		Console.WriteLine(b);
		
		
		b = b + a;
		a = b.Substring(0,b.Length-a.Length);
		b = b.Substring(a.Length);
		Console.WriteLine(a);
		Console.WriteLine(b);
