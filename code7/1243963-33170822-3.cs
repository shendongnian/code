    XmlReaderSettings xrs = new XmlReaderSettings();
    xrs.ConformanceLevel = ConformanceLevel.Fragment;
    XDocument doc = new XDocument(new XElement("root"));
    XElement root = doc.Descendants().First();
    
    using(var ms = new StreamWriter(new MemoryStream()))
    {
        ms.Write(data);
        ms.Flush();
        ms.BaseStream.Position = 0;
        using (StreamReader fs = new StreamReader(ms.BaseStream))
        //using (StreamReader fs = new StreamReader("file.xml"))
        {
            using (XmlReader rdr = XmlReader.Create(fs, xrs))
            {
                while (rdr.Read())
                {
                    if (rdr.NodeType == XmlNodeType.Element)
                    {
                        root.Add(XElement.Load(rdr.ReadSubtree()));
                    }
                }
            }
        }
    }
