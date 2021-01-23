    class InitialInspectionNotes
    {
        public string Location { get; set; }
        public string LocationNote { get; set; }
        public string CodeCost { get; set; }
        public string EstimatedTime { get; set; }
    }
    var xdoc = XDocument.Load("yourpath\filename.xml");
    var dataXml = xdoc.Descendants("initialInspection").Elements("inspectionNote").Select(n => new InitialInspectionNotes()
    {
        Location = n.Element("location").Value,
        LocationNote = n.Element("locationNote").Value,
        CodeCost = n.Element("CostCode").Value,
        EstimatedTime = n.Element("estimatedTime").Value
    
    }).ToList();
    
    var xmlList = new List<object>();
    for (int i = 0; i < dataXml.Count; i++)
    {
        xmlList.Add(dataXml[i]);
    }
