    Dictionary<string, string> TimeZones = new Dictionary<string, string> 
    {
       {"PST", "-08:00"},
       {"PDT", "-07:00"},
       // more as needed 
    };
    string s = "08:45:29 May 25, 2016 PDT";
	
	StringBuilder sb = new StringBuilder(s);
	
	foreach(var kvp in TimeZones)
		sb = sb.Replace(kvp.Key,kvp.Value);
	
	s = sb.ToString();
	
	DateTime dt;
	bool success = DateTime.TryParseExact(s, 
									      "HH:mm:ss MMM dd, yyyy zzz",
										  CultureInfo.InvariantCulture,
										  DateTimeStyles.AdjustToUniversal,
										  out dt);
