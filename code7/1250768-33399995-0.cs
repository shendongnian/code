    // You will have to use System.Xml.Linq library
    public class Phone // the only class I have
    {
        public string PhoneType { get; set; }
        public string Number { get; set; }
    }
    public XElement CreateTelecomNode(List<Phone> phones)
    {
        var telecom = new XElement("Telecom");
        foreach (var item in phones)
        {
            telecom.Add(new XElement("TeleType", item.PhoneType));
            telecom.Add(new XElement("TeleNumber", item.Number));
        }
        return telecom;
    }
