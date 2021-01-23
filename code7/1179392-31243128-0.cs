    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string input =
                  "<Product ID=\"Sample A\" UserTypeID=\"TYPE_PRD_RANGE\">" +
                    "<Values AttributeId = \"AAAAAA\">" +
                      "<Value AttributeId = \"BBBBBB\">Value1\"</Value>" +
                      "<Value AttributeId = \"CCCCCC\">Value2\"</Value>" +
                      "<Value AttributeId = \"DDDDDD\">Value3\"</Value>" +
                      "<Value AttributeId = \"EEEEE\">Value4\"</Value>" +
                    "</Values>" +
                    "<Product ID=\"Sample A_1\" UserTypeID=\"SUB_RANGE\">" +
                      "<Values AttributeId = \"ZZZZZZ\">" +
                        "<Value AttributeId = \"YYYYYY\">Value1\"</Value>" +
                        "<Value AttributeId = \"CCCCCC\">Value2\"</Value>" +
                        "<Value AttributeId = \"DDDDDD\">Value3\"</Value>" +
                        "<Value AttributeId = \"BBBBBB\">Value4\"</Value>" +
                      "</Values>" +
                    "</Product>" +
                    "<Product ID=\"Sample A_1_1\" UserTypeID=\"ITEM\">" +
                      "<Values AttributeId = \"12345\">" +
                        "<Value AttributeId = \"N12345\">Value1\"</Value>" +
                        "<Value AttributeId = \"A12345\">Value2\"</Value>" +
                        "<Value AttributeId = \"C12345\">Value3\"</Value>" +
                        "<Value AttributeId = \"F12345\">Value4\"</Value>" +
                      "</Values>" +
                    "</Product>" +
                  "</Product>";
                  XDocument doc = XDocument.Parse(input);
                
                  var results =doc.Descendants("Product").Select(x => new {
                      id = x.Attribute("ID").Value,
                      valuesId = x.Element("Values").Attribute("AttributeId").Value,
                      values = x.Element("Values").Descendants("Value").Select(y => new {
                         valueId = y.Attribute("AttributeId").Value,
                         value = (string)y
                      }).ToList()
                  }).ToList();
            }
        }
    }
