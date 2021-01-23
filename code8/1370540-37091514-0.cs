    private void CompressToZip(string fileName, Dictionary<string, byte[]> fileList)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in fileList)
                {   
                    var demoFile = archive.CreateEntry(file.Key);
                    using (var entryStream = demoFile.Open())
                    using (var b = new BinaryWriter(entryStream))
                    {
                        b.Write(file.Value);
                    }
                }
            }
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
        }
    }
