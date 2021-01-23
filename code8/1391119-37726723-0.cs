    void Main()
    {
    	string a = "Bug A is resolved (XID: X015)";
    	string b = "Bug B is resolved (ZID: X016)";
    	string c = "Bug C is resolved (Data issue) (SID: X017)";
    	
    	var regex = new System.Text.RegularExpressions.Regex(@"(\([^(]*\))$");
    	
    	Console.WriteLine(string.Format("a: {0}", regex.IsMatch(a) ? "YES" : "NO"));
    	Console.WriteLine(string.Format("b: {0}", regex.IsMatch(b) ? "YES" : "NO"));
    	Console.WriteLine(string.Format("c: {0}", regex.IsMatch(c) ? "YES" : "NO"));
    	
    	var aMatches = regex.Matches(a);
    	var bMatches = regex.Matches(b);
    	var cMatches = regex.Matches(c);
    	
    	Console.WriteLine(string.Format("a: {0}", aMatches[aMatches.Count - 1]));
    	Console.WriteLine(string.Format("b: {0}", bMatches[bMatches.Count - 1]));
    	Console.WriteLine(string.Format("c: {0}", cMatches[cMatches.Count - 1]));
    }
