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
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                Node root = new Node();
                string input =
                    "<root>" +
                        "<node id=\"1\">" +
                            "<nodeName>node1</nodeName>" +
                            "<node id=\"2\">" +
                                "<nodeName>node2</nodeName>" +
                                "<node id=\"21\">" +
                                    "<nodeName>node21</nodeName>" +
                                "</node>" +
                                "<node id=\"22\">" +
                                    "<nodeName>node22</nodeName>" +
                                "</node>" +
                            "</node>" +
                            "<node id=\"3\">" +
                                "<nodeName>node3</nodeName>" +
                                "<node id=\"31\">" +
                                    "<nodeName>node31</nodeName>" +
                                "</node>" +
                            "</node>" +
                            "<node id=\"4\">" +
                                "<nodeName>node4</nodeName>" +
                                "<node id=\"41\">" +
                                    "<nodeName>node41</nodeName>" +
                                "</node>" +
                            "</node>" +
                        "</node>" +
                    "</root>";
                XElement  element = XElement.Parse(input);
                doc = new XmlDocument();
                doc.LoadXml(element.ToString());
                XmlNode node = (XmlNode)doc;
                root.AddNode(node, root);
                
            }
        }
        public class Node
        {
            public static Node root { get; set; }
            public int id { get; set; }
            public string nodeName { get; set; }
            public List<Node> children { get; set; }
            public string text { get; set; }
            public void AddNode(XmlNode inXmlNode, Node inTreeNode)
            {
                // Loop through the XML nodes until the leaf is reached.
                // Add the nodes to the TreeView during the looping process.
                if (inXmlNode.HasChildNodes)
                {
                    //Check if the XmlNode has attributes
                    if (inXmlNode.Attributes != null)
                    {
                        foreach (XmlAttribute att in inXmlNode.Attributes)
                        {
                            string name = att.Name;
                            if (name == "id")
                            {
                                inTreeNode.id = int.Parse(att.Value);
                            }
                        }
                    }
                    var nodeList = inXmlNode.ChildNodes;
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        var xNode = inXmlNode.ChildNodes[i];
                        Node tNode = new Node() { nodeName = xNode.Name};
                        if (inTreeNode.children == null)
                            inTreeNode.children = new List<Node>();
                        inTreeNode.children.Add(tNode);
                        AddNode(xNode, tNode);
                    }
                }
                else
                {
                    // Here you need to pull the data from the XmlNode based on the
                    // type of node, whether attribute values are required, and so forth.
                    inTreeNode.text = (inXmlNode.OuterXml).Trim();
                }
            }
        }
    }
    ​
