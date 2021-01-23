    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<Data a=\"a\" b=\"b\" c=\"c\" d=\"d\"><Date runDt=\"01-01-1900\" /></Data>\n" +
                    "<Data a=\"a\" b=\"b\" c=\"c\" d=\"d\"><Date runDt=\"01-01-1900\" /></Data>\n" +
                    "<Data a=\"a\" b=\"b\" c=\"c\" d=\"d\"><Date runDt=\"01-01-1900\" /></Data>\n" +
                    "<Data a=\"a\" b=\"b\" c=\"c\" d=\"d\"><Date runDt=\"01-01-1900\" /></Data>\n" +
                    "<Data a=\"a\" b=\"b\" c=\"c\" d=\"d\"><Date runDt=\"01-01-1900\" /></Data>\n";
                //xml can only contain one root tag.  Need to wrap xml in root tag if one is missing
                input = string.Format("<Root>{0}</Root>", input);
                XDocument doc = XDocument.Parse(input);
                
                // if loading from file
                //string input = File.ReadAllText(filename);
                //input = string.Format("<Root>{0}</Root>", input);
                //XDocument doc = XDocument.Load(filename);
                var results = doc.Descendants("Data").Select(x => new
                {
                    a = x.Attribute("a").Value,
                    b = x.Attribute("b").Value,
                    c = x.Attribute("c").Value,
                    d = x.Attribute("d").Value,
                    date = DateTime.Parse(x.Element("Date").Attribute("runDt").Value)
                }).ToList();
            }
        }
    }
    ​
