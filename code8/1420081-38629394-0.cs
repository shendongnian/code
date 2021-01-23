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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement values = doc.Descendants("Values").FirstOrDefault();
                List<XElement> elements = values.Elements().ToList();
                for (int index = elements.Count() - 1; index >= 0; index--)
                {
                    elements[index].ReplaceWith(elements[index].Elements());
                }
            }
        }
    }
