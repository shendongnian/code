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
                TD td = new TD()
                {
                    Code = "Test",
                    Message = "Yusuf",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    CTs = new List<CT>() {
                        new CT() { Foo = 1},
                        new CT() { Foo = 2},
                        new CT() { Foo = 3},
                    },
                    TEs = new List<TE>() {
                        new TE() { Bar = 1},
                        new TE() { Bar = 2},
                        new TE() { Bar = 3},
                    }
                };
               using (MemoryStream stream = new MemoryStream()) 
                {
                    byte[] data =  Serialize(td);
                    XmlDocument doc = new XmlDocument();
                    string xml = Encoding.UTF8.GetString(data); 
                    doc.LoadXml(xml);
                   // str = Convert.ToBase64String(stream.GetBuffer(),0,(int)stream.Length); 
                } 
         
            }
            public static byte[] Serialize(TD tData)
            {
                using (var ms = new MemoryStream())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TD));
                    serializer.Serialize(ms, tData);
                    return ms.ToArray();
                }
            }
            public static TD Deserialize(byte[] tData)
            {
                using (var ms = new MemoryStream(tData))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(TD));
                    return (TD)xs.Deserialize(ms);
                }
            }
        }
        [XmlRoot("CT")]
        public class CT
        {
            [XmlElement(ElementName = "Foo", Order = 1)]
            public int Foo { get; set; }
        }
        [XmlRoot("TE")]
        public class TE
        {
            [XmlElement(ElementName = "Bar", Order = 1)]
            public int Bar { get; set; }
        }
        [XmlRoot("TD")]
        public class TD
        {
            [XmlElement(ElementName = "CTs",  Order = 1)]
            public List<CT> CTs { get; set; }
            [XmlElement(ElementName = "TEs", Order = 2)]
            public List<TE> TEs { get; set; }
            [XmlElement(ElementName = "Code", Order = 3)]
            public string Code { get; set; }
            [XmlElement(ElementName = "Message", Order = 4)]
            public string Message { get; set; }
            [XmlElement(ElementName = "StartDate", Order = 5)]
            public DateTime StartDate { get; set; }
            [XmlElement(ElementName = "EndDate", Order = 6)]
            public DateTime EndDate { get; set; }
        }
    }
    ​
