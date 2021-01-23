    public static void Main()
	{
		var s = "my text has $1 per Lap to someone.";
		
		Console.WriteLine(Test(s));
		Console.WriteLine(Test2(s));
	}
		
	static object Test(string s)
	{			
		var tab = s.Remove(s.IndexOf(" Lap"))       // remove everything after " Lap" 
			       .Substring(s.IndexOf(" $") + 2)  // remove everything before " $"
		           .Split(' ');
		return new { Amount = tab[0], Per = tab[1] };
	}
		
	static object Test2(string s)
	{
		var tab = s.Split(' ');
		var amount = tab.Single(t => t.StartsWith("$")).Substring(1);
		var per = tab[Array.FindIndex(tab, t => t.StartsWith("$")) + 1];
			
		return new { Amount = amount, Per = per };
	}
