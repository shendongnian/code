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
                XElement CfgAgentGroup = doc.Descendants("CfgAgentGroup").Where(x => (int)x.Element("agentDBIDs").Element("DBID").Attribute("value") == 103).FirstOrDefault();
                XElement cfgGroup = CfgAgentGroup.Element("CfgGroup");
            }
        }
    }
    ​
