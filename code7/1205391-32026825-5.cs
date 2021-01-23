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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string file = File.ReadAllText(FILENAME);
                file = file.Replace("standalone=\"true\"", "standalone=\"yes\"");
                XDocument doc = XDocument.Parse(file);
                List<string> steamID64 = doc.Descendants("steamID64").Select(x => (string)x).ToList();
            }
        }
     
    }​
