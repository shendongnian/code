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
                 "<Root>" +
                 "<Fields>" +
                  "<Field FieldId = \"1\" Value=\"1908551075\" FieldTitle=\"Ref Id\" FieldType=\"Text\" />" +
                  "<Field FieldId = \"2\" Value=\"Mary\" FieldTitle=\"First Name\" FieldType=\"Text\" />" +
                  "<Field FieldId = \"3\" Value=\"Crippen\" FieldTitle=\"Last Name\" FieldType=\"Text\" />" +
                  "</Fields>" +
                  "</Root>";
                
                XDocument xDoc = XDocument.Parse(input);
                var results = xDoc.Descendants("Fields").Select(x => new {
                    ID = x.Descendants("Field").Where(y => y.Attribute("FieldTitle").Value == "Ref Id").Select(z => z.Attribute("Value").Value).FirstOrDefault(),
                    firstName = x.Descendants("Field").Where(y => y.Attribute("FieldTitle").Value == "First Name").Select(z => z.Attribute("Value").Value).FirstOrDefault(),
                    lastName = x.Descendants("Field").Where(y => y.Attribute("FieldTitle").Value == "Last Name").Select(z => z.Attribute("Value").Value).FirstOrDefault(),
                }).ToList();
                   
            }
        }
    }
    ​
