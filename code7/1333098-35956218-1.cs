            var doc = new XmlDocument();
            var root = doc.AppendChild(doc.CreateElement("Item"));
            foreach (var item in files)
            {
                var name = root.AppendChild(doc.CreateElement("Name"));
                name.InnerText = item;
            }
            using (var writer = new XmlTextWriter("data.xml", null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
