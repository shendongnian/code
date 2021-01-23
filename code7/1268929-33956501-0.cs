            XDocument xDoc1 = XDocument.Load(inputFileName);
            var elems = xDoc1.Element("Root").Elements("Main");
            XElement xInstall = elems.LastOrDefault(a => a.Attribute("Name").Value == "Install");
            XElement xUninstall = elems.LastOrDefault(a => a.Attribute("Name").Value == "Uninstall");
            XElement xDiscard = elems.LastOrDefault(a => a.Attribute("Name").Value == "Discard");
            XDocument xdoc2 = new XDocument();
            xdoc2.Add(
                new XElement("Root", new XElement[]
                {
                    xInstall,
                    xDiscard,
                    xUninstall
                })
            );
            xdoc2.Save(ouputFileName);
