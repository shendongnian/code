    string data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>0x52341<element1 value=\"3\"><sub>1</sub></element1>0x234512 <element1><sub><element>2</element></sub></element1>0x52341<element2><sub>3</sub></element2> <element2><sub>4</sub></element2>0x4312";
    
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
