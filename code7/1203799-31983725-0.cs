    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                saveXmlPath();
            }
            const string FILENAME = @"c:\temp\test.xml";
            public static void saveXmlPath()
            {
                CastleConfigTop ccTop = new CastleConfigTop();
                
                XmlSerializer serializer = new XmlSerializer(typeof(CastleConfigTop));
               XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("xsi","xsd/c5c.xsd");
                ns.Add("", "http://www.w3.org/2001/XMLSchema-instance");
      
                using (TextWriter writer = new StreamWriter(FILENAME))
                {
                    serializer.Serialize(writer, ccTop, ns);
                }
            }
        }
        [XmlRoot(ElementName = "CastleConfigTop", Namespace = "xsi")]
        public class CastleConfigTop
        {
        }
    }
    ​
