    [XmlRoot(ElementName = "root", Namespace = "http://213.63.189.121/webservicenos")]
    public class ArrayOfVenda
    {
        [XmlElement("venda")]
        public List<venda> VendaList { get; set; }
    }
