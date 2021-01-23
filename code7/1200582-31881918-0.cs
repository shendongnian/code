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
                string input = 
                "<?xml version=\"1.0\"?>" +
                "<DATASET xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"  +
                  "<ROW>" +
                      "<Columns type=\"string\" maxLength=\"5\">" + 
                      "<Name>ColumnName1</Name>rah rah rah</Columns>" + 
                  "</ROW>" +
                "</DATASET>";
                XDocument doc = XDocument.Parse(input);
                foreach (XElement row in doc.Descendants("ROW"))
                {
                    // <?xml version="1.0"?>
                    //<DATASET xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                    //  <ROW>
                    //      <ColumnName1 type="string" maxLength="5">rah rah rah</ColumnName1>
                    //  </ROW>
                    //</DATASET>
                    List<XAttribute> attributes = row.Element("Columns").Attributes().ToList();
                    XElement eName = row.Element("Columns").Element("Name");
                    string name = eName.Value;
                    string value = eName.NextNode.ToString();
                    XElement newElement = new XElement(name,value);
                    newElement.Add(attributes);
                    row.Descendants().Remove();
                    row.Add(newElement);   
                 
                }
            }
        }
    }
    ​
