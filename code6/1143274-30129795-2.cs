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
            const string FILENAME = @"c:\temp\testxml";
            static void Main(string[] args)
            {
                CreateManufactoryOrder createManufacturyOrder = new CreateManufactoryOrder()
                {
                    op = new Op(){
                        auth = new Auth(){
                            user = "User",
                            password = "Password"
                            },
                            client = "01425787000104",
                            downLoadCode  = "0460.0001",
                            partNumber = "M268-773-C4-BRA-3",
                            flexPO = "887614_364",
                            terminals = new List<Terminal>(){
                                new Terminal(){ m_String = "529-995-835"},
                                new Terminal(){ m_String = "529-995-836"},
                                new Terminal(){ m_String = "529-995-837"},
                                new Terminal(){ m_String = "529-995-838"}
                            }
                    }
                };
                Test(createManufacturyOrder);
            }
            static public void Test(CreateManufactoryOrder createManufacturyOrder)
            {
     
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(CreateManufactoryOrder));
                serializer.Serialize(writer, createManufacturyOrder);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                string XML = File.ReadAllText(FILENAME);
                using (TextReader reader = new StringReader(XML))
                {
                    CreateManufactoryOrder result = (CreateManufactoryOrder)serializer.Deserialize(reader);
                }
            }
        }
        [XmlRoot("CreateManufactoryOrder")]
        public class CreateManufactoryOrder
        {
            [XmlElement("op")]
            public Op op { get; set; }
        }
        [XmlRoot("op")]
        public class Op
        {
            [XmlElement("Auth")]
            public Auth auth { get; set; }
            [XmlElement("Client")]
            public string client;
            [XmlElement("DownloadCode")]
            public string downLoadCode { get; set; }
            [XmlElement("PartNumber")]
            public string partNumber { get; set; }
            [XmlElement("FlexPO")]
            public string flexPO { get; set; }
            [XmlElement("Terminals")]
            public List<Terminal> terminals { get; set; }
        }
        [XmlRoot("Auth")]
        public class Auth
        {
            [XmlElement("User")]
            public string user { get; set; }
            [XmlElement("Password")]
            public string password { get; set; }
        }
        public class Terminal
        {
            [XmlElement("String")]
            public string m_String { get; set; }
        }
    }
    ​
