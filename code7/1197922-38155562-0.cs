    using (var fstream = File.OpenRead(dlpath))
    {
        using (var zstream = new GZipStream(fstream, CompressionMode.Decompress))
        {
            using (var xstream = new CleanTextReader(zstream))
            {
                var ser = new XmlSerializer(typeof(MyType));
                prods = ser.Deserialize(XmlReader.Create(xstream, new XmlReaderSettings() { CheckCharacters = false })) as MyType;
            }
        }
    }
