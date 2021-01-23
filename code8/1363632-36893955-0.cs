    private static void ReadTempFileStuff(ZipArchive archive) // adw
        {
            var sessionArchives = archive.Entries.Where(x => x.FullName.StartsWith(@"temp_directory_contents")).ToArray();
            if (sessionArchives != null && sessionArchives.Length > 0)
            {
                foreach (ZipArchiveEntry entry in sessionArchives)
                {
                    FileInfo info = new FileInfo(@"C:\" + entry.FullName);
                    if (!info.Directory.Exists)
                    {
                        Directory.CreateDirectory(info.DirectoryName);
                    }
                    entry.ExtractToFile(@"C:\" + entry.FullName,true);
                }
            }
        }
