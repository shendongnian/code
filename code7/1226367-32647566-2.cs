    for(int cnt = 1 ....) {
        Regex rex = new Regex(@"\d+(\.\d+)?");
		MatchCollection mac = rex.Matches("your string of numbers");
		
		
		string string4Hash = string.Format("{0}", cnt);
		foreach (Match match in mac)
		{
			string4Hash = string.Format("{0}|{1}", string4Hash, double.Parse(match.Value));
		}  
	}
               
