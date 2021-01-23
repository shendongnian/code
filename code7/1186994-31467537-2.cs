    public static string ToXml(ClassToBeSerialized cts)
    {
        var dcs = new DataContractSerializer(typeof(ClassToBeSerialized));
        using (var sb = new StringWriter())
        {
            using (var xs = XmlWriter.Create(sb, new XmlWriterSettings() { Indent = true }))
            {
                dcs.WriteObject(xs, cts);
            }
            return sb.ToString();
        }
    }
    public static ClassToBeSerialized FromXml(string xml)
    {
        var dcs = new DataContractSerializer(typeof(ClassToBeSerialized));
        return (ClassToBeSerialized)dcs.ReadObject(XmlReader.Create(new StringReader(xml)));
    }
