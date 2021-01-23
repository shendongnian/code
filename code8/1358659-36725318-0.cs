    void Main()
    {
        try
        {
            string xmlDoc = "<POSLog MajorVersion=\"6\" MinorVersion=\"0\" FixVersion=\"0\"><Cash Amount = \"100\"></Cash></POSLog>";
    
            XmlSerializer xser = new XmlSerializer(typeof(POSLog));
            POSLog fromXml = xser.Deserialize(new StringReader(xmlDoc)) as POSLog;
    
            string json = JsonConvert.SerializeObject(fromXml); 
    
            POSLog fromJson = JsonConvert.DeserializeObject<POSLog>(json);
    
            Console.WriteLine("MajorVersion=" + fromJson.MajorVersion);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    // Define other methods and classes here
    public class Cash
    {
        public string Amount { get; set; }
    }
    
    public class POSLog
    {
        [XmlAttribute]
        public string MajorVersion { get; set; }
        [XmlAttribute]
        public string MinorVersion { get; set; }
        [XmlAttribute]
        public string FixVersionive { get; set; }
    
        public Cash Cashx { get; set; }
    }
