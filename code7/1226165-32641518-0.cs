	public static string FixJSONTimes(string source)
	{
		string result = source;
		// use Regex to locate bad time strings
		var re = new Regex("\"([\\d-]+)T24:00:00Z\"");
		foreach (Match match in re.Matches(result))
		{
			// parse out date portion of string
			// NB: we want this to throw if the date is invalid too
			DateTime dateVal = DateTime.Parse(match.Groups[1].Value);
				
			// rebuild string in correct format, adding a day
			string rep = string.Format("\"{0:yyyy-MM-dd}T00:00:00Z\"", dateVal.AddDays(1));
			
			// replace broken string with correct one
			result = result.Substring(0, match.Index) + rep + result.Substring(match.Index + match.Length);
		}
		
		return result;
	}
