    using System.IO.Compression;
    using System.IO;
    public static string GetTextfileFromZip(string zipFilepath, string txtFilename)
    {
        using (ZipArchive zipArchive = ZipFile.Open(zipFilepath, ZipArchiveMode.Read))
        {
            ZipArchiveEntry entry = GetZipArchiveEntry(zipArchive, txtFilename);
            using (Stream stream = entry.Open())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
    public static ZipArchiveEntry GetZipArchiveEntry(ZipArchive zipArchive, string zipEntryName)
    {
        return zipArchive.Entries.First<ZipArchiveEntry>(n => n.FullName.Equals(zipEntryName));
    }
