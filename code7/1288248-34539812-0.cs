    public static void Main(string[] args)
    {
        var serializer = new XmlSerializer(typeof (ConnectionList));
        var connections = ((ConnectionList)serializer.Deserialize(new StreamReader("data.xml"))).Connections;
        foreach (var connection in connections)
        {
            Console.WriteLine(connection.IP);
        }
        Console.ReadLine();
    }
    [XmlRoot("connections")]
    public class ConnectionList
    {
        [XmlElement("connection")]
        public List<Connection> Connections { get; set; } = new List<Connection>();
    }
    [XmlType("connection")]
    public class Connection
    {
        [XmlElement("description")] public string Description;
        [XmlElement("ip")] public string IP;
        [XmlElement("name")] public string Name;
        [XmlElement("port")] public int Port;
    }
