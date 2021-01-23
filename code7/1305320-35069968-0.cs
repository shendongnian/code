        private static string GetName(string filename)
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
            var xDocument = XDocument.Parse(xml.ToString());
            var xmlRoot = xDocument.Root;
            var cfgAgentGroup = xmlRoot.Element("CfgAgentGroup");
            var cfgGroup = cfgAgentGroup.Element("CfgGroup");
            var name = cfgGroup.Element("name");
            var nameValue = name.Attribute("value");
            var value = nameValue.Value;
            return value;
        }
