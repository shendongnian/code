    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement message = doc.Descendants("message")
                    .Where(x => (x.Element("location") != null) && 
                        (x.Element("location").Attribute("filename") != null) &&
                        (x.Element("location").Attribute("filename").Value  == "Studentform.txt") &&
                        (x.Element("location").Attribute("line") != null) &&
                        (x.Element("location").Attribute("line").Value  == "38")).FirstOrDefault();
                XElement translation = message.Element("translation");
                if(translation != null)
                {
                    translation.Value = "Translation of \"From\"";
                }
            }
        }
    }
