            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> errorLogs = doc.Descendants().Where(x => x.Name.LocalName == "ErrorLog").ToList();
                XNamespace ns = errorLogs[0].Name.Namespace;
                var sKeys = errorLogs.Select(x => new {
                    sKey = x.Element(ns + "sKey").Value
                }).ToList();
            }
