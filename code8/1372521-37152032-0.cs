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
                XElement obs = doc.Descendants().Where(x => x.Name.LocalName == "Obs").FirstOrDefault();
                string TIME_PERIOD = obs.Attribute("TIME_PERIOD").Value;
                string OBS_VALUE = obs.Attribute("OBS_VALUE").Value;
            }
        }
    }
