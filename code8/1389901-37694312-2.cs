		string s1 = "\"\"Being Ordered Around by You Makes Me Really Angry Somehow!!!\" \"Whaddaya Mean, 'Somehow'!!?\"\"",
			   s2 = "\"\"Omae ni Meirei Sareru no wa Nanka Haratatsu!!!\" \"Nankatte Nani!!?\"\"";
		
		Console.WriteLine("Before 1  : " + s1);
		Console.WriteLine("Before 2  : " + s2);
		Regex r = new Regex("\"(\"[^\"]*\")[^\"]*(\"[^\"]*\")\"");
		Match m = r.Match(s1);
		Console.WriteLine("After 1.1 : " + m.Groups[1].Value);
		Console.WriteLine("After 1.2 : " + m.Groups[2].Value);
		
		m = r.Match(s2);
		Console.WriteLine("After 2.1 : " + m.Groups[1].Value);
		Console.WriteLine("After 2.2 : " + m.Groups[2].Value);
