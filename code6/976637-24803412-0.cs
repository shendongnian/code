    [XmlRoot("Node", Namespace="http://your.companies.namespace")]
    public class ListPrijemkaRequest {
        [XmlElement("requestPrijemka")]
        public List<RequestPrijemka> Requests { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("lst", "http://your.companies.namespace");
            XmlSerializer xser = new XmlSerializer(typeof(ListPrijemkaRequest));
            xser.Serialize(Console.Out, new ListPrijemkaRequest(), ns);
        }
    }
