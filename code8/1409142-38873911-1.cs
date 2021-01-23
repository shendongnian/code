	using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Open(file.FullName, true))
	{
		WorkbookPart workbookpart = excelDoc.WorkbookPart;
		ConnectionsPart connPart = workbookpart.ConnectionsPart;
		string spreadsheetmlNamespace = @"http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		NameTable nt = new NameTable();
		XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
		nsManager.AddNamespace("sh", spreadsheetmlNamespace);
		XmlDocument xdoc = new XmlDocument(nt);
		xdoc.Load(connPart.GetStream());
		XmlNode oxmlNode = xdoc.SelectSingleNode("/sh:connections/sh:connection/sh:dbPr/@connection", nsManager);
		string newConnection = ReplaceInitialCatalog(oxmlNode.Value, repConfig.DbName);
		oxmlNode.Value = oxmlNode.Value.Replace(oxmlNode.Value, newConnection);
		
		//Truncates part with FeedData
		connPart.FeedData(connPart.GetStream());
		xdoc.Save(connPart.GetStream());
	}
