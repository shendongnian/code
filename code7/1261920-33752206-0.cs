    private static void ExtractAndLoadXml(string zipFilePath, XmlDocument doc)
    {
        using(FileStream fs = File.OpenRead(zipFilePath))
        {
            ExtractAndLoadXml(fs, doc);
        }
    }
    private static void ExtractAndLoadXml(Stream fs, XmlDocument doc)
    {
        ZipFile zipArchive = new ZipFile(fs);
        foreach (ZipEntry elementInsideZip in zipArchive)
        {
            String ZipArchiveName = elementInsideZip.Name;
            if (ZipArchiveName.Equals("MyZMLFile.xml"))
            {
                Stream zipStream = zipArchive.GetInputStream(elementInsideZip);
                doc.Load(zipStream);
                break;
            }
            else if (ZipArchiveName.Contains(".zip"))
            {
                Stream zipStream = zipArchive.GetInputStream(elementInsideZip);
                string zipFileExtractPath = Path.GetTempFileName();
                FileStream extractedZipFile = File.OpenWrite(zipFileExtractPath);
                zipStream.CopyTo(extractedZipFile);
                extractedZipFile.Flush();
                extractedZipFile.Close();
                try
                {
                    ExtractAndLoadXml(zipFileExtractPath, doc);
                }
                finally
                {
                    File.Delete(zipFileExtractPath);
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        string location = null;
        XmlDocument xmlDocument = new XmlDocument();
        ExtractAndLoadXml(location, xmlDocument);
    }
