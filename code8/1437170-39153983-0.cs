    using (ZipArchive zip = ZipFile.Open("test.zip", ZipArchiveMode.Create))
    {
        var entry = zip.CreateEntry("File Name.txt");
        using (StreamWriter sw = new StreamWriter(entry.Open()))
        {
            sw.Write("Some Text");  
        }
    }
    using (ZipArchive zip = ZipFile.Open("test.zip", ZipArchiveMode.Read))
    {
        foreach (ZipArchiveEntry entry in zip.Entries)
        {
            using (StreamReader sr = new StreamReader(entry.Open()))
            {
                var result = sr.ReadToEnd();
            }
        }
    }
