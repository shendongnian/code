            XElement root = XElement.Load("input.xml");
            // Extract Sequences ordered by 'Top'
            var orderedtabs = root.Elements("Designer").Elements("Sequence")
                                  .OrderBy(xtab => (float)xtab.Element("Top"))
                                  .ToArray();
            // Remove Sequences from xml
            root.Descendants("Designer").Elements("Sequence").Remove();
            // Reinsert Sequences in new order under the Designer element
            XElement designer = root.Descendants("Designer").FirstOrDefault();
            foreach (XElement tab in orderedtabs)
            {
                designer.Add(tab);
            }
            root.Save("xmlfile" + ".xml");
