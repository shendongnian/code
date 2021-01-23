    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name: {0}", GetNameFromFileString(File.ReadAllText("file.txt")));
            Console.WriteLine("Name: {0}", GetNameFromFile("file.txt"));
        }
        private static string GetNameFromFileString(string filecontent)
        {
            Regex r = new Regex("(?<Xml><ConfData>.*</ConfData>)", RegexOptions.Singleline);
            var match = r.Match(filecontent);
            var xmlString = match.Groups["Xml"].ToString();
            return GetNameFromXmlString(xmlString);
        }
        private static string GetNameFromFile(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var xml = new StringBuilder();
            var isXml = false;
            foreach (var line in lines)
            {
                if (line.Contains("<ConfData>"))
                    isXml = true;
                if (isXml)
                    xml.Append(line.Trim());
                if (line.Contains("</ConfData>"))
                    isXml = false;
            }
            var text = xml.ToString();
            return GetNameFromXmlString(text);
        }
        private static string GetNameFromXmlString(string text)
        {
            var xDocument = XDocument.Parse(text);
            var cfgAgentGroupt = xDocument.Root.Element("CfgAgentGroup");
            var cfgGroup = cfgAgentGroupt.Element("CfgGroup");
            var name = cfgGroup.Element("name");
            var nameValue = name.Attribute("value");
            var value = nameValue.Value;
            return value;
        }
    }
