    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication87
    {
        namespace Linq
        {
            class Program
            {
                const string FILENAME = @"c:\temp\test.xml";
                static void Main(string[] args)
                {
                    List<string> acceptableElements = new List<string>(){"Name", "Street", "City", "State", "Zip", "Country"};
                    XDocument doc = XDocument.Load(FILENAME);
                    List<XElement> addresses = doc.Descendants("Address").ToList();
                    XElement billing = addresses.Where(x => x.Attribute("Type").Value == "Billing").FirstOrDefault();
                    addresses.Remove();
                    XElement po = (XElement)doc.FirstNode;
                    po.Add(billing);
                }
            }
        }
    }
