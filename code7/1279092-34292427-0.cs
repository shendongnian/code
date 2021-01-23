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
                    "<Root>" +
                        "<Employee>" + 
                            "<id>001</id>" + 
                            "<Name>Sam</Name>" + 
                        "</Employee>" +
                        "<Employee>" +
                            "<id>002</id>" + 
                            "<Name>john,Donald</Name>" + 
                        "</Employee>" +
                    "</Root>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> duplicates = doc.Descendants("Employee").Where(x => x.Element("Name").Value.Contains(",")).ToList();
                foreach (XElement duplicate in duplicates)
                {
                    string[] names = duplicate.Element("Name").Value.Split(new char[] { ',' });
                    List<XElement> newEmployees = new List<XElement>();
                    foreach(string name in names)
                    {
                        XElement newEmployee = XElement.Parse(duplicate.ToString());
                        XElement nameElement = newEmployee.Element("Name");
                        nameElement.Value = name;
                        newEmployees.Add(newEmployee);
                    }
                    duplicate.ReplaceWith(newEmployees);
                }
            }
        }
    }
    ​
