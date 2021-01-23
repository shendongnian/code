    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var entries = doc.Descendants("forms").FirstOrDefault().Element("required").Elements("entry").ToList();
                int count = 0;
                foreach (XElement entry in entries)
                {
                    entry.ReplaceWith(new XElement("entry_" + (++count).ToString(), entry.Elements()));
                }
            }
        }
     
    }
