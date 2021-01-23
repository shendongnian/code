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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                    //string xml = "";
                    //xml += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                    //xml += "<root>";
                    //xml += "   <success>true</success>";
                    //xml += "   <data>";
                    //xml += "      <item>";
                    //xml += "         <Barcode>20450000817386</Barcode>";
                    //xml += "         <StateId>1</StateId>";
                    //xml += "         <WareReceiverId />";
                    //xml += "      </item>";
                    //xml += "   </data>";
                    //xml += "   <errors />";
                    //xml += "   <warnings />";
                    //xml += "   <info />";
                    //xml += "</root>";
                Root root = new Root()
                {
                    success = true,
                    data = new Data()
                    {
                        item = new Item()
                        {
                            Barcode = "20450000817386",
                            StateId = 1,
                            WareReceiverId = null 
                        },
                    },
                    errors = string.Empty,
                    warnings = string.Empty
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, root);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root  newRoot = (Root)xs.Deserialize(reader);
                    
            }
        }
        [XmlRoot("root")]
        public partial class Root
        {
            [XmlElement("success")]
            public Boolean success { get; set; }
            [XmlElement("data")]
            public Data  data { get; set; }
            [XmlElement("errors")]
            public string errors { get; set; }
            [XmlElement("warnings")]
            public string warnings { get; set; }
        }
        [XmlRoot("data")]
        public partial class Data
        {
            [XmlElement("item")]
            public Item item { get; set; }
        }
        [XmlRoot("item")]
        public partial class Item
        {
            [XmlElement("Barcode")]
            public string Barcode { get; set; }
            [XmlElement("StateId")]
            public Nullable<int> StateId { get; set; }
            [XmlElement("WareReceiverId")]
            public int? WareReceiverId { get; set; }
        }
    }
    ​
