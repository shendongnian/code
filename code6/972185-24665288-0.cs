    var settings = new XmlWriterSettings{ ... initialization here };
    using (var writer = XmlWriter.Create(outputFilename, settings)
    {
        SqlCommand cmd = new SqlCommand(queryString, connection);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            writer.WriteStartElement("record");
            writer.WriteElementString("field1", record[0].ToString());
            writer.WriteElementString("field2", record[1].ToString());
            writer.WriteEndElement();
        }
    }
