    XmlWriterSettings set = new XmlWriterSettings();
    set.ConformanceLevel = ConformanceLevel.Document;
    set.Indent = true;
    //comm is your command object
    using (XmlReader reader = comm.ExecuteXmlReader())
    using (XmlWriter writer = XmlWriter.Create(File.Open("testing.xml",FileMode.OpenOrCreate,FileAccess.Write),set)) 
    {
          while (!reader.EOF)
          {
              writer.WriteStartElement("test");
              writer.WriteNode(reader, true);
              writer.WriteEndElement();
          }
    }
