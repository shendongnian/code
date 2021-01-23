    public static byte[] ZipFile(string csvFullPath)
    {
        using (FileStream csvStream = File.Open(csvFullPath, FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream zipToCreate = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry fileEntry = archive.CreateEntry(Path.GetFileName(csvFullPath));
                    using (var entryStream = fileEntry.Open())
                    {
                        csvStream.CopyTo(entryStream);
                    }
                }
                return zipToCreate.ToArray();
            }
        }
    }
