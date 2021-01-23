    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        [XmlRoot("Document")]
        public class Document
        {
            [XmlText(DataType = "base64Binary")]
            public byte[] Binary { get; set; }
            [XmlAttribute]
            public int AddAttribute { get; set; }
        }
    }
    ​
