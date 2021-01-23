    public class Stations
    {
        [XmlElement(ElementName = "add", Namespace = "")]
        public StationConfiguration StationConfiguration { get; set; }
    }
    [XmlType(AnonymousType = true, Namespace = "")]
    public class StationConfiguration
    {
        readonly Regex OnlyAlphaNumericWithNoSpaces = new Regex("^[a-zA-Z0-9]*$");
        public StationConfiguration() { }
        public StationConfiguration(string comment, string ftpUsername, string ftpPassword, string destinationFolderPath)
        {
            Comment = comment;
            FtpUsername = ftpUsername;
            FtpPassword = ftpPassword;
            DestinationFolderPath = destinationFolderPath;
        }
        public bool IsValidStation()
        {
            return OnlyAlphaNumericWithNoSpaces.IsMatch(Comment);
        }
        public bool IsValidUsername()
        {
            return OnlyAlphaNumericWithNoSpaces.IsMatch(FtpUsername);
        }
        public bool IsValidPassword()
        {
            return FtpPassword.Contains(' ') == false;
        }
        public bool IsValidFolderPath()
        {
            return Directory.Exists(DestinationFolderPath);
        }
        private string _comment;
        [XmlAttribute]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value.ToUpper();
            }
        }
        [XmlAttribute]
        public string FtpUsername { get; set; }
        [XmlAttribute]
        public string FtpPassword { get; set; }
        [XmlAttribute]
        public string DestinationFolderPath { get; set; }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            const string hardCodedConfigFilePath = @"test.xml";
            sol1(hardCodedConfigFilePath);
            sol2(hardCodedConfigFilePath);
            sol3(hardCodedConfigFilePath);
        }
        public static void sol1(string hardCodedConfigFilePath)
        {
            
            string xmlDocumentText = File.ReadAllText(hardCodedConfigFilePath);
            var doc = new XmlDocument();
            doc.LoadXml(xmlDocumentText);
            var docElem = new XmlDocument();
            docElem.CreateXmlDeclaration("1.0", "utf-8", "yes");
            var node = doc.DocumentElement["StationsSection"];
            //Create a document fragment.
            var docFrag = docElem.CreateDocumentFragment();
            //Set the contents of the document fragment.
            docFrag.InnerXml = node.InnerXml;
            //Add the document fragment to the 
            // document.
            docElem.AppendChild(docFrag);
            var reader = new XmlNodeReader(docElem);
            var ser = new XmlSerializer(typeof(Stations));
            object obj = ser.Deserialize(reader);
        }
        public static void sol2(string hardCodedConfigFilePath)
        {
            string xmlDocumentText = File.ReadAllText(hardCodedConfigFilePath);
            var doc = new XmlDocument();
            doc.LoadXml(xmlDocumentText);
            var attr = doc.DocumentElement["StationsSection"].ChildNodes[0].ChildNodes[0].Attributes;
            // Check that attributes exist ... 
            var stationConfiguration = new StationConfiguration(attr["Comment"].Value
                                                                , attr["FtpUsername"].Value
                                                                , attr["FtpPassword"].Value
                                                                , attr["DestinationFolderPath"].Value);
        }
        public static void sol3(string hardCodedConfigFilePath)
        {
            var xdoc = XElement.Load(hardCodedConfigFilePath);
            var config = xdoc.Descendants("Stations").Elements("add").FirstOrDefault();
            // Check that attributes exist ...
            var stationConfiguration = new StationConfiguration(config.Attribute("Comment").Value
                                , config.Attribute("FtpUsername").Value
                                , config.Attribute("FtpPassword").Value
                                , config.Attribute("DestinationFolderPath").Value);
        }
