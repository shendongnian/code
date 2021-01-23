    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<q1:InventoryFeed xmlns:q1=\"http://thecompany.com/\">\n" +
                        "<q1:InventoryHeader>\n" +
                            "<q1:version>1.4</q1:version>\n" +
                        "</q1:InventoryHeader>\n" +
                        "<q1:inventory>v" +
                            "<q1:sku>WMSkuCap0180</q1:sku>\n" +
                            "<q1:quantity>\n" +
                                "<q1:unit>EACH</q1:unit>\n" +
                                "<q1:amount>3</q1:amount>\n" +
                            "</q1:quantity>\n" +
                            "<q1:fulfillmentLagTime>1</q1:fulfillmentLagTime>\n" +
                        "</q1:inventory>\n" +
                    "</q1:InventoryFeed>\n";
                string pattern1 = @"<[^/][^:]+:";
                string output = Regex.Replace(input, pattern1, "<");
                string pattern2 = @"</[^:]+:";
                output = Regex.Replace(output, pattern2, "</");
                //using xml linq
                XElement element = XElement.Parse(input);
                foreach (var node in element.DescendantNodesAndSelf())
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        ((XElement)node).Name = ((XElement)node).Name.LocalName;
                    }
                }
            }
        }
    }
    ​
