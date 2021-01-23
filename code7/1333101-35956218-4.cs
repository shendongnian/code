    public class Program
    {
        [XmlType("Item")]
        public class Item
        {
            [XmlElement("Name")]
            public string[] Files { get; set; }
        }
        static string SerialiseToXml<T>(T obj, bool isFormatted = false)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var stringBuilder = new StringBuilder();
            var xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = isFormatted };
            using (var xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(xmlWriter, obj, ns);
                return stringBuilder.ToString();
            }
        }
        static void Main(string[] args)
        {
            string[] files = {"Apple.txt", "Orange.exe", "Pear.docx", "Banana.xml", "Papaya.xls", "Passionfruit.cs"};
            var item = new Item {Files = files};
            var xml = SerialiseToXml(item, true);
            Console.WriteLine(xml);
        }
    }
