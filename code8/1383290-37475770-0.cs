    public class Servers
    {        
        [XmlElement("Server")]
        public ServerDetails[] ServersDetails { get; set; }
    }
    
    public class ServerDetails
    {
        public string ServerName { get; set; }
        public string ServerIP { get; set; }
    }
    private void GetXMLData()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Servers));
    
      using (FileStream stream = File.OpenRead("D:\\Resource.xml"))
      {
        Servers list = (Servers)serializer.Deserialize(stream);
        //Exception here
      }
    }
