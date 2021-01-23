    public class Parser
    {    
    
    public string CurrentProjectDirectory{ get; set; }
    public void UpdateXml()
    {
        var wwwDirectory = Path.Combine(CurrentProjectDirectory, @"www"); // www directory
        var path = Path.Combine(wwwDirectory, @"beheer_extern\config");
        //Creates the beheer_extern\config directory if it doesn't exist, otherwise nothing happens.
        Directory.CreateDirectory(path);
        var instellingenFile = Path.Combine(path, "instellingen.xml");
        var instellingenFileDb = Path.Combine(path, "instellingenDb.xml");
        //Create instellingen.xml if not already existing
        if (!File.Exists(instellingenFile))
        {
            using (var writer = XmlWriter.Create(instellingenFile, _writerSettings))
            {
                var xDoc = new XDocument(
                    new XElement("database", string.Empty, new XAttribute("version", 4)));
                xDoc.WriteTo(writer);
            }
        }
      }
    }
