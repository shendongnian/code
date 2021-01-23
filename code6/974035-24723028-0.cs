     static void Main(string[] args)
    {
        ProcessWrite().Wait();
        Console.Write("Done ");
        Console.ReadKey();
    }
    static Task ProcessWrite()
    {
        string filePath = @"C:\Users\Srikanth\Desktop\sample.xml";
        return WriteTextAsync(filePath);
    }
    static async Task WriteTextAsync(string FilePath)
    {
        XDocument doc = XDocument.Load(FilePath);
        XElement item = new XElement("item", "text");
        XElement xmlroot = doc.Element("root");
        if (xmlroot != null)
        {
            xmlroot.Add(item);
            //doc.Save(FilePath); <-- this works, but locks the file
            using (FileStream fs = new FileStream(FilePath,
                   FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                doc.Save(fs);
            }
        }
    }
