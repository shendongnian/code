    private static Invoice LoadInvoice(string fileName)
    {
        var serializer = new XmlSerializer(typeof(Invoice));
        if (!File.Exists(fileName))
        {
            return null;
        }
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            return (Invoice)serializer.Deserialize(fs);
        }
    }
