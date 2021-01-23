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
                    "<Root>" +
                    "<Product ID=\"Sample A\" UserTypeID=\"TYPE_PRD_RANGE\">" +
                      "<MultiValues>" +
                      "<Values>" +
                       "<Value AttributeId = \"Att_1\">Value1</Value>" +
                      "</Values>" +
                      "</MultiValues>" +
                      "<Values AttributeId = \"Att_2\">" +
                        "<Value AttributeId = \"Att_3\">Value1</Value>" +
                        "<Value AttributeId = \"Att_4\">Value2</Value>" +
                        "<Value AttributeId = \"Att_5\">Value3</Value>" +
                        "<Value AttributeId = \"Att_6\">Value4</Value>" +
                      "</Values>" +
                      "<Product ID=\"Sample A_1\" UserTypeID=\"SUB_RANGE\">" +
                        "<Values AttributeId = \"Att_2_5\">" +
                          "<Value AttributeId = \"Att_2_4\">Value1</Value>" +
                          "<Value AttributeId = \"Att_2_3\">Value2</Value>" +
                          "<Value AttributeId = \"Att_2_1\">Value3</Value>" +
                          "<Value AttributeId = \"Att_2_2\">Value4</Value>" +
                        "</Values>" +
                      "</Product>" +
                      "<Product ID=\"Sample A_1_1\" UserTypeID=\"ITEM\">" +
                        "<Values AttributeId = \"12345\">" +
                          "<Value AttributeId = \"Att_2_1_1\">Value1</Value>" +
                          "<Value AttributeId = \"Att_2_2_1\">Value2</Value>" +
                          "<Value AttributeId = \"Att_2_3_1\">Value3</Value>" +
                          "<Value AttributeId = \"Att_2_4_1\">Value4</Value>" +
                        "</Values>" +
                      "</Product>" +
                    "</Product>" +
                    "</Root>";
     
                XElement products = XElement.Parse(input);
                var results = products.Elements("Product").Select(x => new
                {
                    ID = x.Attribute("ID").Value,
                    valueId = x.Descendants("Value").Attributes("AttributeId").FirstOrDefault().Value,
                    products = x.Elements("Product").Select(y => new
                    {
                        ID = y.Attribute("ID").Value,
                        Name = y.Attribute("UserTypeID").Value,
                        values = y.Element("Values").Elements("Value").Select(z => new
                        {
                            ID = z.Attribute("AttributeId").Value,
                            Value = (string)z
                        }).ToList()
                        .Select(aa =>  string.Join(",", new string[] { aa.ID, aa.Value })).ToList()
                    }).ToList()
                    .Select(ac => ac.values.Select(ad => string.Join(",", new string[] { ac.ID, ac.Name, ad }))).ToList()
                }).ToList()
                .Select(ae => ae.products.Select(af => af.Select(ag => string.Join(",", new string[] { ae.ID, ae.valueId, ag })).ToList()).ToList()).ToList();
            }
            
        }
    }
