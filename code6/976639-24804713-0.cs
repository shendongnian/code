    [XmlRoot("listPrijemkaRequest", Namespace = "http://your.companies.namespace/lst")]
    public class ListPrijemkaRequest {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlAttribute("prijemkaVersion")]
        public string PrijemkaVersion { get; set; }
        [XmlElement("requestPrijemka")]
        public List<RequestPrijemka> Requests { get; set; }
    }
    public class RequestDateFilter
    {
        [XmlElement(ElementName = "dateFrom")]
        public DateTime DateFrom { get; set; }
        [XmlElement(ElementName = "dateTill")]
        public DateTime DateTill { get; set; }
    }
    public class RequestPrijemka {
        [XmlElement("filter", Namespace = "http://your.companies.namespace/ftr")]
        public RequestDateFilter Filter { get; set; }
    }
    static class Program {
        static void Main() {
            var ns = new XmlSerializerNamespaces();
            ns.Add("lst", "http://your.companies.namespace/lst");
            ns.Add("ftr", "http://your.companies.namespace/ftr");
            var xser = new XmlSerializer(typeof(ListPrijemkaRequest));
            var obj = new ListPrijemkaRequest
                {
                    Version = "2.0",
                    PrijemkaVersion = "2.0",
                    Requests = new List<RequestPrijemka>
                        {
                            new RequestPrijemka
                                {
                                    Filter = new RequestDateFilter {DateFrom = DateTime.Now, DateTill = DateTime.Now}
                                }
                        }
                };
            xser.Serialize(Console.Out, obj, ns);
            Console.ReadLine();
        }
    }
