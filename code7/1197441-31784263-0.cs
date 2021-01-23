    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<customers>" +
                      "<customer id=\"2\">" +
                        "<name>ted smith</name>" +
                        "<addresses>" +
                          "<address1>" +
                               "<line1></line1>" +
                          "</address1>" +
                          "<address2>" +
                               "<line1></line1>" +
                               "<line2></line2>" +
                          "</address2>" +
                        "</addresses>" +
                      "</customer>" +
                      "<customer id=\"322\">" +
                        "<name>smith mcsmith</name>" +
                        "<addresses>" +
                          "<address1>" +
                               "<line1></line1>" +
                               "<line2></line2>" +
                          "</address1>" +
                          "<address2>" +
                               "<line1></line1>" +
                               "<line2></line2>" +
                          "</address2>" +
                        "</addresses>" +
                      "</customer>" +
                    "</customers>";
                StringReader sReader = new StringReader(input);
                XmlReader reader = XmlReader.Create(sReader);
                Node root = new Node();
                ReadNode(reader, root);
            }
            static bool ReadNode(XmlReader reader, Node node)
            {
                Boolean done = false;
                Boolean endElement = false;
                while(done = reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (node.name.Length == 0)
                            {
                                node.name = reader.Name;
                                GetAttrubutes(reader, node);
                            }
                            else
                            {
                                Node newNode = new Node();
                                newNode.name = reader.Name;
                                if (node.children == null)
                                {
                                    node.children = new List<Node>();
                                }
                                node.children.Add(newNode);
                                GetAttrubutes(reader, newNode);
                                done = ReadNode(reader, newNode);
                            }
                            break;
                        case XmlNodeType.EndElement:
                            endElement = true;
                            break;
                        case XmlNodeType.Text:
                            node.text = reader.Value;
                            break;
                        case XmlNodeType.Attribute:
                            if (node.attributes == null)
                            {
                                node.attributes = new Dictionary<string, string>();
                            }
                            node.attributes.Add(reader.Name, reader.Value);
                            break;
                    }
                    if (endElement)
                        break;
                }
                return done;
            }
            static void GetAttrubutes(XmlReader reader, Node node)
            {
                for (int i = 0; i < reader.AttributeCount; i++)
                {
                    if (i == 0) node.attributes = new Dictionary<string, string>();
                    reader.MoveToNextAttribute();
                    node.attributes.Add(reader.Name, reader.Value);
                }
            }
        }
        public class Node
        {
            public string name = string.Empty;
            public string text = string.Empty;
            public Dictionary<string, string> attributes = null;
            public List<Node> children = null;
        }
    }
    ​
