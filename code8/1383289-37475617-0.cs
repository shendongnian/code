    public class ServerDetails
    {
       public string ServerName { get; set; }
       public string ServerIP { get; set; }        
    }
    public class ServerList
    {
       [XmlArray("Servers")]
       [XmlArrayItem("Server", Type = typeof(ServerDetails))]
       public ServerDetails[] Servers { get;set;}        
    }
    private void GetXMLData()
    {
       XmlSerializer serializer = new XmlSerializer(typeof(ServerList));
       using (FileStream stream = File.OpenRead("D:\\Resource.xml"))
       {
          var list = (ServerList)serializer.Deserialize(stream);
          //Exception here
       }
    }
