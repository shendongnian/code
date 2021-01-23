            XmlDocument doc = new XmlDocument();
            string appPath = Directory.GetCurrentDirectory();
            string folder = appPath;
            string filter = "*.*";
            string[] files = Directory.GetFiles(folder, filter);
            using (XmlTextWriter writer = new XmlTextWriter("data.xml", null))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Items");
                foreach (string item in files)
                {
                    string string1 = item;
                    string string2 = appPath;
                    string result = string1.Replace(string2, "");
                    writer.WriteElementString("Item","", result);
                    Console.WriteLine(result);
                    writer.Formatting = Formatting.Indented;
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                doc.Save(writer);
            }
