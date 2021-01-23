         using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Xml;
        using System.Xml.Serialization;
        namespace TestXmlSerializer
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var g = new Group
                    {
                        Name="g2",
                        Keys = new[] {
                            new Key { Username="a" },
                            new Key { Password="b" }
                        }
                    };
                    Group g2;
                    var xs = new XmlSerializer(typeof(Group));
                    var s = string.Empty;
                    using (var tw = new StringWriter()) {
                        using (var xw = XmlWriter.Create(tw))            
                            xs.Serialize(xw, g);               
                        s = tw.ToString();
                    }
                    Console.WriteLine(s);
            
                    using (var ms = new StringReader(s))
                    {               
                        using (var xw = XmlReader.Create(ms))
                            g2 = xs.Deserialize(xw) as Group;
                    }
                    Console.WriteLine(g2.Name);
                }
            }
            [Serializable]
            public class Key
            {
                [XmlAttribute]
                public string Title;
                [XmlAttribute]
                public string Username;
                [XmlAttribute]
                public string Password;
                [XmlAttribute]
                public string Url;
                [XmlAttribute]
                public string Notes;
            }
            [Serializable]
            public class Group
            {
                [XmlAttribute]
                public string Name;
                [XmlElement]
                public Key[] Keys;
            }
        }
