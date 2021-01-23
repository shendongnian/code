        public static void AddDirToZip(string source, string targetzip)
        {
            using (FileStream zipToOpen = new FileStream(targetzip, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry;
                    DirectoryInfo d = new DirectoryInfo(source);
                    FileInfo[] Files = d.GetFiles("*");
                    foreach (FileInfo file in Files)
                    {
                        readmeEntry = archive.CreateEntryFromFile(file.FullName, d.Name + "/" + file.Name);
                    }
                }
            }
        }
