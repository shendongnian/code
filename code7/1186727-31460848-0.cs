    void Main()
    {
    	const string hardCodedConfigFilePath = @"\\ai-vmdc1\RedirectedFolders\jlambert\Documents\MyApp.exe.config";
    	string xmlDocumentText = File.ReadAllText(hardCodedConfigFilePath);
    	XmlDocument doc = new XmlDocument();
    	//doc.Schemas.Add(, xsdPath
    	//Console.WriteLine(xmlDocumentText);
    	doc.LoadXml(xmlDocumentText);
    	XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement["StationsSection"]);
    	string firstStationConfiguration = doc.DocumentElement["StationsSection"].ChildNodes[0].OuterXml;//.InnerXml; //here's the chunk that contains my data
    	XmlSerializer ser = new XmlSerializer(typeof(Stations));
    	//	Console.WriteLine(xmlDocumentText);
    	//object obj = ser.Deserialize(reader);
    	Console.WriteLine(firstStationConfiguration);
    	using (StringReader stringReader = new StringReader(firstStationConfiguration))
    	{
    		Stations sc = (Stations)ser.Deserialize(stringReader);
    		Console.WriteLine(sc.Comment);
    		Console.WriteLine(sc.FtpUsername);
    		Console.WriteLine(sc.FtpPassword);
    		Console.WriteLine(sc.DestinationFolderPath);
    	}
    }
    
    // Define other methods and classes here
    [Serializable]
    public class Stations
    {
    	[XmlAttribute("Comment")]
    	public string Comment { get; set;}
    	[XmlAttribute]
    	public string FtpUsername { get; set;}
    	[XmlAttribute]
    	public string FtpPassword { get; set;}
    	[XmlAttribute]
    	public string DestinationFolderPath { get; set;}
    }
