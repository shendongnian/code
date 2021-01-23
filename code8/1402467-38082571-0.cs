        public void SaveToFile(string path)
        {
            XmlSerializer xmlWriter = XmlSerializer.FromTypes(new[] { typeof(YourClass) })[0];
            TextWriter writer = new StreamWriter(path + "\\Whatever.bla"); // need file name
            xmlWriter.Serialize(writer, this);
            writer.Close();
        }
