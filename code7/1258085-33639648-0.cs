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
                string item =
                    "<Message xmlns=\"http://www.example.com/schema/msc/message\">" +
                      "<Params>" +
                        "<Events xmlns=\"http://www.example.com/schema/msc/referral\" Code=\"AC\">" +
                          "<ref:User xmlns:ref=\"http://www.example.com/schema/msc/referral\" Name=\"asdf\"/>" +
                        "</Events>" +
                      "</Params>" +
                    "</Message>";
                XElement root = XElement.Parse(item);
                XNamespace ns1 = root.Name.Namespace;
                XNamespace ns2 = root.Descendants().Where(x => x.Name.LocalName == "Events").FirstOrDefault().Name.Namespace;
            }
        }
    }​
