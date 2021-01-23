		XDocument doc = XDocument.Load(filepath);		
		var copyitems = doc.Descendants("GLOBAL")	// Read all descendants		
			.Select(s=> 
				{
					var splits = s.Value.Split(new string[] {"@srcdir@", "@destdir@"}, StringSplitOptions.RemoveEmptyEntries); // split the string to separate source and destination.
					return new { Source = splits[0].Replace(",",""), Destination = splits[1].Replace(",","")};
				})
			.ToList();
