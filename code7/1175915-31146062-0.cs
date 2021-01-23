    NameTable nt = new NameTable();
    object feature = nt.Add("feature");
    object descriptor = nt.Add("descriptor");
    var settings = new XmlReaderSettings();
    settings.NameTable = nt;
    using (var reader = XmlReader.Create("descriptors.xml", settings))
    {
        int i = -1;
        int ii = 0;
        while (reader.Read())
        {
            if (object.ReferenceEquals(feature, reader.Name))
            {
                ObjectDescriptors[i, ii] = reader.ReadElementContentAsFloat();
                ii++;
                if (ii == 64) ii = 0;
            }
            else if (reader.NodeType == XmlNodeType.Element && object.ReferenceEquals(descriptor, reader.Name)) i++;
        }
    }
