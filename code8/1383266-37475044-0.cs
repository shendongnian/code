    private IEnumerable<DateTime> GetDates(string str)
    {
    	var dateSearcherRegex = new Regex(@"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3}");
    	
    	foreach (Match match in dateSearcherRegex.Matches(str))
    	{
    		var matchedString = match.Groups[0].Value;
    		DateTime date;
    		if (DateTime.TryParseExact(matchedString, "yyyy-MM-dd hh:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
    		{
    			yield return date;
    		}
    	}
    }
