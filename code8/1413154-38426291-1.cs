    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "InformationTuple")
                    {
                        reader.ReadToFollowing("InformationTuple");
                    }
                    if (!reader.EOF)
                    {
                        XElement subtree = (XElement)XElement.ReadFrom(reader);
                        Info.info.Add(new Info() { state = (string)subtree.Element("state"), weight = (int)subtree.Element("weight") });
                    }
                }
            }
        }
        public class Info
        {
            public static List<Info> info = new List<Info>();
            public string state { get; set; }
            public int weight { get; set; }
        }
    }
