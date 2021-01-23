		Console.WriteLine("\r\nComparing 2 constants\r\n");
		
		object c = "d";
		
		Console.Write("a == c: ");
		
		Console.WriteLine(a == c);
		
		Console.WriteLine("AreValueEquals: " + AreValueEquals(a,c));
		
		Console.WriteLine("Equals: " + a.Equals(c)); 	
