    static void SharpCompressEx(string sevenZPath)
        {
            using (Stream stream = File.OpenRead(sevenZPath))
            {
                using (var archive = ArchiveFactory.Open(stream))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                            entry.WriteToDirectory(@"C:\Temp", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
        }
