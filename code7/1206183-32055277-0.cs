    public static List<VyplatnePasky> DeserialzieRozuctovanieMzdy(ref List<VyplatnePasky> _pasky, string sPath)
    {
        var formattedAreaPairReport =
		tryToGetItemsFromDocument
		(
		    sPath,
			document=>from d in document.Descendants("FormattedReport".AddNamespace())
                      .Descendants("FormattedAreaPair".AddNamespace())
                      .Descendants("FormattedAreaPair".AddNamespace())
                      select d.Element("FormattedAreaPair".AddNamespace()),
			"DeserialzieRozuctovanieMzdy"
		);
        addItemsToVyplatnePasky(formattedAreaPairReport, ref _pasky);
        return _pasky;
    }
	
    public static List<VyplatnePasky> DeserializeVyplatnePasky(string sPath)
    {
        List<VyplatnePasky> _pasky = new List<VyplatnePasky>();
        var formattedAreaPairReport =
		tryToGetItemsFromDocument
		(
			sPath,
			document=>from d in document.Descendants("FormattedReport".AddNamespace())
                      select d.Element("FormattedAreaPair".AddNamespace()),
			"DeserializeVyplatnePasky"
		);
        addItemsToVyplatnePasky2(formattedAreaPairReport, _pasky);
		return _pasky;
    }
	private static void addItemsToVyplatnePasky(IEnumerable<XElement> formattedAreaPairReport, ref List<VyplatnePasky> _pasky)
	{
        if (formattedAreaPairReport.Count() > 0)
		{
			//check if any sequence contains any matching elements
			var GotElements = formattedAreaPairReport.Elements("FormattedAreaPair".AddNamespace()).Where(n=>n.Attribute("Level").Value == "3" && n.Attribute("Type").Value == "Group");
			if (GotElements == null)
			{
				InsertErrorMessage("There are no matching elements under <formattedAreaPairReport>.", "DeserialzieRozuctovanieMzdy");
				return;
			}
	
			foreach (XElement xElement in GotElements)
			{
				RozuctovanieMzda_Values(xElement, ref _pasky);
			}
		}
	}
	private static void addItemsToVyplatnePasky2(IEnumerable<XElement> formattedAreaPairReport, List<VyplatnePasky> _pasky)
	{
		foreach (XElement xElement in formattedAreaPairReport.Elements("FormattedAreaPair".AddNamespace()))
		{
			VyplatnePasky _paska = new VyplatnePasky();
			VyplatnePasky_Items(xElement, ref _paska);
			
			_pasky.Add(_paska);
		}
	}
	
	private static IEnumerable<XElement> tryToGetItemsFromDocument(string sPath, Func<XDocument, IEnumerable<XElement>> query, string name)
    {
        XDocument document = XDocument.Load(sPath);
        var report = query(document);
        if (report.Count() == 0)
        {
            //empty;
            InsertErrorMessage("<formattedAreaPairReport> contains no data! No Data to parse from.", name);
        }
		return report;
    }
