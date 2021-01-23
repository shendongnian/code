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
                    "<products>" +
                        "<product>" +
                            "<attributes>" +
                                "<att name=\"Name\" value=\"TOTO\" />" +
                                "<att name=\"Surname\" value=\"Toto\" />" +
                                "<att name=\"Age\" value=\"10\" />" +
                            "</attributes>" +
                        "</product>" +
                        "<product>" +
                            "<attributes>" +
                                "<att name=\"Name\" value=\"TATA\" />" +
                                "<att name=\"Surname\" value=\"Tata\" />" +
                                "<att name=\"Age\" value=\"20\" />" +
                            "</attributes>" +
                        "</product>" +
                        "<product>" +
                            "<attributes>" +
                                "<att name=\"Name\" value=\"TITI\" />" +
                                "<att name=\"Surname\" value=\"Titi\" />" +
                                "<att name=\"Age\" value=\"30\" />" +
                            "</attributes>" +
                        "</product>" + 
                    "</products>";
                XElement products = XElement.Parse(xml);
                var results = products.Elements("product").Select(x => new
                {
                    name = x.Descendants("att").Where(y => y.Attribute("name").Value == "Name").Select(z => z.Attribute("value").Value).FirstOrDefault(),
                    age = x.Descendants("att").Where(y => y.Attribute("name").Value == "Age").Select(z => (int)z.Attribute("value")).FirstOrDefault()
                }).ToList();
                string name = results[2].name;
                int age = results[2].age;
            }
        }
     
    }
    ​
