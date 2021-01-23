    public void Save(Models models)
    {
        using (XmlWriter writer = XmlWriter.Create(/*path to your config file*/))
        {
            writer.WriteStartDocument();
            writer.WriteRaw("\n");
            writer.WriteStartElement("models");
            foreach (Model m in models.models)
            {
                writer.WriteRaw("\n\t");
                writer.WriteStartElement("model");
                writer.WriteRaw("\n\t\t");
                writer.WriteElementString("name", m.name);
                writer.WriteRaw("\n\t\t");
                writer.WriteStartElement("firmwarefiles");
                for (int i = 0; i < m.firmwarefiles.Count; i++)
                {
                    writer.WriteRaw("\n\t\t\t");
                    writer.WriteStartElement("firmwarefile");
                    writer.WriteRaw("\n\t\t\t\t");
                    writer.WriteElementString("filename", m.firmwarefiles[i].filename);
                    writer.WriteRaw("\n\t\t\t\t");
                    writer.WriteElementString("version", m.firmwarefiles[i].version.ToString());
                    writer.WriteRaw("\n\t\t\t\t");
                    writer.WriteElementString("datecode", m.firmwarefiles[i].datecode.ToString());
                    writer.WriteRaw("\n\t\t\t");
                    writer.WriteEndElement();
                }
                writer.WriteRaw("\n\t\t");
                writer.WriteEndElement();
                writer.WriteRaw("\n\t");
                writer.WriteEndElement();
            }
            writer.WriteRaw("\n");
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
