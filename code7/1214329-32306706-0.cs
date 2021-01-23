	public List<Tuple<string,int>> loadSocks()
	{
		var result = new List<Tuple<string, int>>();
		var input = Path.GetFullPath(Path.Combine(Application.StartupPath, "Exploit1/socks-list.txt"));
		var r = new Regex(@"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}):(\d{1,5})");
		
		foreach (Match match in r.Matches(input))
		{
			string ip = match.Groups[1].Value;
			int port =  Convert.ToInt32(match.Groups[2].Value);
			
			result.Add(new Tuple<string,int>(ip, port));
		}
		
		return result;
	}
