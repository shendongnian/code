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
                string name = "gopi";
                string lastname = "ch";
                string graduation = "b.tech";
                string designation = "Engineer";
                XElement personalData = new XElement("person", new XElement[] {
                    new XElement("personaldata", new XElement[] {
                        new XElement("name", name),
                        new XElement("lastname", lastname)
                    }),
                    new XElement("Educationadata", new XElement[] {
                        new XElement("Graduation", graduation),
                        new XElement("designation", designation)
                    })
                });
            }
        }
    }
    ​
