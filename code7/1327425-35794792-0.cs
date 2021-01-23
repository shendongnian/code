            XDocument doc = XDocument.Load("input.xml");
            foreach (XElement entry in doc.Descendants("Entry").ToList())
            {
                foreach (var group in entry.Elements().Except(entry.Elements("pos")).GroupBy(child => child.ElementsBeforeSelf("pos").Last()))
                {
                    group.Remove();
                    group.Key.ReplaceWith(new XElement("body", group));
                }
            }
            doc.Save("output.xml");
