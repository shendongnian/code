    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                MyCollection myCollection = new MyCollection();
                XmlSerializer xs = new XmlSerializer(typeof(MyCollection.I_Collection));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                MyCollection.I_Collection newRoot = (MyCollection.I_Collection)xs.Deserialize(reader);
            }
        }
        public partial class MyCollection
        {
            [XmlRoot("I-collection")]
            public class I_Collection
            {
                [XmlElement("I")]
                public List<I> itemsField { get; set; }
            }
            [XmlRoot("I")]
            public partial class I
            {
                [XmlAttribute("EMAIL")]
                public string EMAILField { get; set; }
                [XmlAttribute("FIRST_NAME")]
                public string FIRST_NAMEField { get; set; }
                [XmlAttribute("INDIVIDUAL_KEY")]
                public string INDIVIDUAL_KEYField { get; set; }
                [XmlAttribute("LANGUAGE_CODE")]
                public string LANGUAGE_CODEField { get; set; }
                [XmlAttribute("LAST_NAME")]
                public string LAST_NAMEField { get; set; }
                [XmlAttribute("USERNAME")]
                public string USERNAMEField { get; set; }
            }
        }
     
        
    }
