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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Root root = new Root()
                {
                    baseClass = new List<BaseClass>(){
                        new InheritorClass1(){ name = "class1"},
                        new InheritorClass2(){ name = "class2"}
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, root);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root newRoot = (Root)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Root")]
        public class Root
        {
            [XmlElement("BaseClass")]
            public List<BaseClass> baseClass { get; set; }
        }
        [XmlRoot("BaseClass")]
        [XmlInclude(typeof(InheritorClass1))]
        [XmlInclude(typeof(InheritorClass2))]
        public class BaseClass
        {
            [XmlElement("name")]
            public string name { get; set; }    
           
        }
        [XmlRoot("InheritorClass1")]
        public class InheritorClass1 : BaseClass
        {
        }
        [XmlRoot("InheritorClass2")]
        public class InheritorClass2 : BaseClass
        {
        }
        
    }
    ​
