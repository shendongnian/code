            var doc = new XmlDocument();
            var root = doc.AppendChild(doc.CreateElement("Item"));
            foreach (var item in files)
            {
                var name = root.AppendChild(doc.CreateElement("Name"));
                name.InnerText = item;
            }
            var xmlWriterSettings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create("data.xml", xmlWriterSettings))
            {
                doc.Save(writer);
            }
