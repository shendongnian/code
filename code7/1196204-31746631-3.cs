    void Main()
    {
    	string xmlString;
    	string path = @"C:\Temp\exampleXmlSO.xml";
    
    	using (StreamReader streamReader = File.OpenText(path))
    	{
    		xmlString = streamReader.ReadToEnd();
    	}
    	XmlSerializer serializer = new XmlSerializer(typeof(FooBars));
    
    
    	using (StringReader stringReader = new StringReader(xmlString))
    	{
    		var myData = (FooBars)serializer.Deserialize(stringReader);
    		Console.WriteLine(myData);
    	}
    }
    
    [XmlRoot(ElementName = "FooBars", Namespace = "http://foos")]
    public class FooBars
    {
    	[XmlElement(ElementName = "Id1", Namespace = "http://bars")]
    	public string Id1 { get; set; }
    
    	[XmlElement(ElementName = "Id2", Namespace = "http://bars")]
    	public string Id2 { get; set; }
    
    	[XmlArray(ElementName = "Info", Namespace = "http://bars"), XmlArrayItem("Data")] //<--
    	public List<Data> Info { get; set; }
    
    }
    
    
    [Serializable]
    public class Data
    {
    	[XmlElement(ElementName = "Field1")]
    	public string Field1 { get; set; }
    
    	[XmlElement(ElementName = "Field2")]
    	public string Field2 { get; set; }
    	
    	[XmlIgnore]
    	public string Field3 { get; set; }
    }
