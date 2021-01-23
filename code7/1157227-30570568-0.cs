    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication32
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = 
                  "<one-of>" +
                      "<item>" + 
            //add item dynamically. // i want to add item here
                      "</item>" +
                      "<item> " +
           //add new items.// i want to add item here
                      "</item>" +
                  "</one-of>";
                XDocument doc = XDocument.Parse(input);
                List<XElement> items = doc.Descendants().Where(x => x.Name == "item").ToList();
                foreach (XElement item in items)
                {
                    XElement newElement = new XElement("newItem", "i want to add item here");
                    item.Add(newElement);
                }
            }
        }
    }
