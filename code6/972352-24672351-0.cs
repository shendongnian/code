	var xml = "<Content> Shape=\"Rectangle\" Tooltip=\"data\" StrokeThickness=\"2\" Tag=\"default\" </Con" +
    "tent>";
	
	
	using(var xmlReader = XmlReader.Create(new StringReader(xml)))
	{
		while(xmlReader.Read())
		{
			var regex = "Tooltip=\"[a-zA-Z0-9]+\"";
			var match  = Regex.Match(xmlReader.Value, regex).Value.Replace("Tooltip=\"", "").Replace("\"", "");
			
			if(!string.IsNullOrEmpty(match))
			{
				var restuledString = match;			
			}			
		}
	}
