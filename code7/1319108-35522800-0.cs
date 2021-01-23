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
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                        "<tables>" +
                          "<table tableName=\"Orders\">" +
                            "<item table=\"Orders\">" +
                              "..." +
                            "</item>" +
                            "<item table=\"Orders\">" +
                              "..." +
                            "</item>" +
                          "</table>" +
                          "<table tableName=\"OrderWithParent\">" +
                            "<item table=\"OrderWithParent\">" +
                              "<column columnName=\"OrderWithParentId\"><![CDATA[156]]></column>" +
                              "<column columnName=\"OrderParentId\"><![CDATA[1]]></column>" +
                              "..." +
                            "</item>" +
                            "<item table=\"OrderWithParent\">" +
                              "<column columnName=\"OrderWithParentId\"><![CDATA[156]]></column>" +
                              "<column columnName=\"OrderParentId\"><![CDATA[1]]></column>" +
                              "..." +
                            "</item>" +
                            "<item table=\"OrderWithParent\">" +
                              "<column columnName=\"OrderWithParentId\"><![CDATA[156]]></column>" +
                              "<column columnName=\"OrderParentId\"><![CDATA[2]]></column>" +
                              "..." +
                            "</item>" +
                          "</table>" +
                        "</tables>";
                XDocument doc = XDocument.Parse(xml);
                XElement[] results = doc.Descendants("table").Elements("item")
                    .Where(y => ((string)y.Attribute("table") == "OrderWithParent") &&
                        (y.Elements("column").Where(z => 
                           (z.Attribute("columnName") != null) &&
                           (z.Attribute("columnName").Value == "OrderParentId") &&
                           (z.Value  == "1")
                           )).Any()
                        )
                    .ToArray();
            }
        }
    }
