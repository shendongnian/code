    public class Client
    {
        [XmlElement("Name")]
        public string ClientName { get; set; }
        public List<Adress> Adresses { get; set; }
    }
    
    public class Adress
    {
        [XmlAttribute("Name")]
        public string AdressName { get; set; }
    
        [XmlElement("Ip")]
        public string IP { get; set; }
    
        [XmlElement("Port")]
        public int port { get; set; }
    }
    
    private void Test()
    {
        var xml = @"<Clients>
    <Client Id=""1"">
    <Name>Granicentro</Name>
    <Adresses>
    <Adress Name=""5648"">
    <Ip>111,111,111,111</Ip>
    <Port>1111</Port>
    </Adress>
    <Adress Name=""2222"">
    <Ip>222,222,222,222</Ip>
    <Port>2222</Port>
    </Adress>
    <Adress Name=""3333"">
    <Ip>333,333,333,333</Ip>
    <Port>3333</Port>
    </Adress>
    </Adresses>
    </Client>
    </Clients>";
    
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "Clients";
        xRoot.Namespace = "";
        xRoot.IsNullable = true;
    
        List<Client> clients;
        XmlSerializer ser = new XmlSerializer(typeof(List<Client>), xRoot);
        using(StringReader r = new StringReader(xml))
        {
            clients = (List<Client>)ser.Deserialize(r);
    
        }
        //Clients collection now has your data.
    }
        
