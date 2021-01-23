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
                    "<Document>" +
                      "<Data>3</Data>" +
                      "<Section1>" +
                        "<Type1>" +
                          "<Entry ID=\"1\">" +
                            "<Date>09/08/2011</Date>" +
                            "<Details1>text</Details1>" +
                          "</Entry>" +
                          "<Entry ID=\"3\">" +
                            "<Date>07/3/2012</Date>" +
                            "<Details2>text</Details2>" +
                          "</Entry>" +
                        "</Type1>" +
                        "<Type2 />" +
                        "<Type3>" +
                          "<Entry ID=\"2\">" +
                            "<Date>08/8/2011</Date>" +
                            "<Details3>text</Details3>" +
                            "<Details4>text</Details4>" +
                          "</Entry>" +
                        "</Type3>" +
                      "</Section1>" +
                      "<Section2>" +
                        "<Type4 />" +
                        "<Type5 />" +
                      "</Section2>" +
                    "</Document>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants().Where(s => s.Name.ToString().StartsWith("Section"))
                    .Where(t => t.Descendants("Date").Count() > 0).Select(u => u.Elements().Where(v => v.Descendants("Date").Count() > 0)
                        .Select(w => w.Elements().Select(x => new {
                            element = x,
                            dates = x.Descendants("Date").FirstOrDefault().Value
                        }).OrderByDescending(y => y.dates).FirstOrDefault().element).ToList()).ToList();
                    
            }
        }
    }
    ​
    ​
