    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<RECORDS>" +
                      "<RECORD>" +
                        "<PROPERTY NAME=\"FNAME\" TYPE=\"string\"></PROPERTY>" +
                        "<PROPERTY NAME=\"LNAME\" TYPE=\"string\">" +
                          "<VALUE>SMITH</VALUE>" +
                        "</PROPERTY>" +
                        "<PROPERTY NAME=\"ZIP\" TYPE=\"string\">" +
                          "<VALUE></VALUE>" +
                        "</PROPERTY>" +
                        "<PROPERTY NAME=\"PHONE\" TYPE=\"string\">" +
                          "<VALUE>5551212</VALUE>" +
                        "</PROPERTY>" +
                      "</RECORD>" +
                  "</RECORDS>";
                XDocument doc = XDocument.Parse(xml);
                DataTable dt = new DataTable();
                List<XElement> properties = doc.Descendants("PROPERTY").ToList();
                //add columns to table
                foreach (XElement property in properties)
                {
                    string name = property.Attribute("NAME").Value;
                    string _type = property.Attribute("TYPE").Value;
                    if(!dt.Columns.Contains(name))
                    {
                        dt.Columns.Add(name, Type.GetType("System." + _type, false, true));
                    }
                }
                //add rows to table
                foreach(XElement record in doc.Descendants("RECORDS").ToList())
                {
                    DataRow newRow = dt.Rows.Add();
                    foreach (XElement property in properties)
                    {
                        string name = property.Attribute("NAME").Value;
                        Type  _type  = Type.GetType("System." + property.Attribute("TYPE").Value, false, true);
                        string value = property.Value;
                        switch (_type.ToString())
                        {
                            case "System.String" :
                                newRow[name] = (string)value;
                                break;
                            case "System.Int" :
                                newRow[name] = int.Parse(value);
                                break;
                        }
                        
                    }
                }
            }
        }
    }
