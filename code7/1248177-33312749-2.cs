    public static class XML
    {
        // Serializes the passed instance of RssChannel into XML file, and saves to runtime memory.
        public static void SaveData(ref RssChannel instance)
        {
            // Objects:
            StreamWriter sw = new StreamWriter("yourXmlFile.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(RssChannel));
            // Save data.
            serializer.Serialize(sw, instance);
            sw.Close();
        }
        // Deserializes data from the XML file, and returns the instance.
        public static RssChannel DeserializeData()
        {
            // Objects:
            RssChannel channelData = new RssChannel();
            XmlSerializer serializer = new XmlSerializer(typeof(RssChannel));
            List<iTunes> iTunesList = new List<iTunes>();
            if (File.Exists("yourXmlFile.xml"))
            {
                FileStream stream = new FileStream("yourXmlFile.xml", FileMode.Open);
                // Deserialize data.
                channelData = (RssChannel)serializer.Deserialize(stream);
                stream.Close();
                // Add data from deserialized iTunes list to list instance.
                if (channelData.iTunesList != null)
                    iTunesList = channelData.iTunesList;
            }
            // Add data to RootData object lists.
            channelData.iTunesList = iTunesList;
            return channelData;
        }
    }
    [XmlRoot("RssChannel")]
    public class RssChannel
    {
        [XmlAttribute("Title")]
        public string Title; // { get; set; }
        [XmlAttribute("Link")]
        public string Link; // { get; set; }
        public List<iTunes> iTunesList; // { get; set; }
    }
    public class iTunes 
    {
        public List<Category> Categories; // { get; set; }
    }
    public class Category
    {
        [XmlAttribute("category")]
        public string category; // { get; set; }
    }
