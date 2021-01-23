        TextAsset asset = Resources.Load("file" + select.ToString()) as TextAsset;
        Stream s = new MemoryStream(asset.bytes);
        BinaryReader br = new BinaryReader(s);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Name>));
        StreamReader sr = new StreamReader(s);
        List<Name> listnames = (List<Name>)xmlSerializer.Deserialize(sr);
