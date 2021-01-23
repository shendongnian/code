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
                "<book time=\"\" title=\"\">" +
                  "<page time=\"\">" +
                    "<title></title>" +
                    "<content>" +
                    "</content>" +
                    "<pgno></pgno>" +
                  "</page>" +
                "</book>";
                XDocument doc = XDocument.Parse(input);
                // or from a file
                //XDocument doc = XDocument.Load(filename);
                XElement title = doc.Descendants("title").FirstOrDefault();
            }
            
        }
    }
    ​
