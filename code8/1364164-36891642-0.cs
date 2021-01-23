        private void CreateZipContentFolder(List<String> zips, string destinationPath)
        {
            if (zips.Any())
            {
                foreach (string zip in zips)
                {
                    string dirName = Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(zip));
                    using (ZipArchive archive = ZipFile.OpenRead(zip))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith("/"))
                            {
                                ZipFile.ExtractToDirectory(zip, destinationPath);
                                break;
                            }
                            else if (!Directory.Exists(dirName))
                            {
                                Directory.CreateDirectory(dirName);
                                ZipFile.ExtractToDirectory(zip, dirName);
                                break;
                            }
                        }
                    }
                }
            }
        }
