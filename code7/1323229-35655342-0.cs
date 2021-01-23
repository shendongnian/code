    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace Ini2XML
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string[] lines = new string[] {
                "root_node1_node2_node3 = value",
                "root_node1_node2_node3 = value1",
                "root_node1_node2_node3_node4 = value",
                "root_node5_node6 = value",
                "root_node5_node6_node7_node8_node8 = value",
                "root_node55 = value2 2232 2 232 2 2 "
               };
    
                XDocument xml = Ini2XMLConverter.ConvertStringArrayToXML(lines);
                xml.Save(Console.Out);
    
            }
    
            public class Ini2XMLConverter
            {
                public static XDocument ConvertStringArrayToXML(IEnumerable<string> lines)
                {
                    if (lines == null) { return null; };
    
                    XDocument xml = new XDocument();
                    foreach (string s in lines)
                    {
                        //define path and value from each line
                        string[] sp = s.Split('=');
    
                        string[] path = sp[0].Trim().Split('_');
                        string value = sp[1].Trim();
    
                        //node to attach the current node
                        XElement attachTo = null;
    
                        for (int i = 0; i < path.Length; i++)
                        {
                            XElement currentNode = null;
    
                            if (i == path.Length - 1)
                            {  //last node it's a TEXT node with value after "="
                                currentNode = new XElement(path[i], value);
                            }
                            else
                            {   //a simple node in the middle
                                currentNode = new XElement(path[i]);
                            }
    
                            // adding the root
                            if (xml.Root == null)
                            {
                                xml.Add(currentNode);
                                attachTo = currentNode;
                                continue;
                            }
                            else if (attachTo == null)
                            {   //If it's a root then the first elements have to be the same 
                                attachTo = xml.Root;
                                continue;
                            }
    
                            //looking for the same name node
                            XElement f = attachTo.Descendants(currentNode.Name).Count() == 0 ? null : attachTo.Descendants(currentNode.Name).First();
    
                            //skip elements with TEXT values 
                            if ((f != null) && (f.LastNode != null) && (f.LastNode.NodeType == System.Xml.XmlNodeType.Text)) { f = null; }
    
                            if (f == null)
                            {
                                //add new node
                                attachTo.Add(currentNode);
                                attachTo = currentNode;
                            }
                            else
                            {   //don't add node if it exists already. Just move pointer to it.
                                attachTo = f;
                            }
    
                        }
                    }
                    return xml;
    
                }
            }
        }
    }
