    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string inputXML = "<elementList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                                "<NodePrime>" +
                                    "<Node>" +
                                         "<NodeA>1</NodeA>" +
                                         "<NodeB>2</NodeB>" +
                                    "</Node>" +
                                    "<Node>" +
                                         "<NodeA>3</NodeA>" +
                                         "<NodeB>4</NodeB>" +
                                    "</Node>" +
                                 "</NodePrime>" +
                            "</elementList>";
                StringReader sReader = new StringReader(inputXML);
                XmlTextReader reader = new XmlTextReader(sReader);
                List<ItemList> itemList = new List<ItemList>();
                while (!reader.EOF)
                {
                    if (reader.Name != "Node")
                    {
                        reader.ReadToFollowing("Node");
                    }
                    if(!reader.EOF)
                    {
                        XElement node = (XElement)XElement.ReadFrom(reader);
                        itemList.Add(new ItemList() {
                           itemA = (int)node.Element("NodeA"),
                           itemB = (int)node.Element("NodeB")
                        });
                    }
                }
            }
        }
        public class ItemList
        {
            public int itemA { get; set; }
            public int itemB { get; set; }
        }
    }
