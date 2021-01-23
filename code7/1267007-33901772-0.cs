    class Note
    {
	    public string Location { get; set; }
	    public string LocationNote { get; set; }
	    public string CodeCost { get; set; }
	    public string EstimatedTime { get; set; }
    }
    var xml = XElement.Load(...your xml path here );
    var data = xml.Descendants("initialInspection").Elements("inspectionNote").Select(n => new     Note()
    {
	    Location = n.Element("location").Value,
    	LocationNote = n.Element("locationNote").Value,
	    CodeCost = n.Element("CostCode").Value,
    	EstimatedTime = n.Element("estimatedTime").Value
    
    }).ToList();
