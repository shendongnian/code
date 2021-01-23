    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace Console.TestApp
    {
        class Program
        {
            static string xmltypeFirst = @"<item>
        <name>John</name>
    </item>";
    
            static string xmltypeSecond = @"<item>
        <name value='Smith' />
    </item>";
    
            static void Main(string[] args)
            {
                var data = xmltypeFirst;
                var result = Deserialize(data).ToList();
                Console.WriteLine("Name: " + result[0].Name);
    
                data = xmltypeSecond;
                result = Deserialize(data).ToList();
                Console.WriteLine("Name: " + result[0].Name);
    
                Console.WriteLine("Press any to key to exit..");
                Console.ReadLine();
            }
    
            private static IEnumerable<Item> Deserialize(string xmlData)
            {
                MemoryStream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlData));
                XDocument doc = XDocument.Load(xmlStream);
    
                var records = from record in doc.Descendants("item").Descendants()
                              select new Item(!record.IsEmpty ? record.Value : record.Attribute("value").Value);
                return records;
            }
        }
    
        [Serializable]
        public class Item
        {
            public Item(string name)
            {
                this.Name = name;
            }
    
            [XmlElement("name")]
            public string Name { get; set; }
        }
    }
