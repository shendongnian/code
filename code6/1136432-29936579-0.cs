    var query =
		xmlDocument
			.Root
			.Elements("user")
			.Where(x => x.Attribute("Id").Value == usrCookieId)
			.Where(x => !x.Elements("city").Any(y => y.Value == "Pathankot"));
	foreach (var xe in query)		
	{
		xe.Add(new XElement("city", drpWhereToGo.SelectedValue));
	}
