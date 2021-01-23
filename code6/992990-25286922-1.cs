    public static Task Empty(string targetDir)
    {
        return Task.Run(async () =>
            {
                foreach (var directory in Directory.GetDirectories(targetDir))
                {
                    await Empty(directory);
                    string[] filelist2 = Directory.GetFiles(directory);
                    foreach (string files in filelist2)
                    {
                        File.SetAttributes(files, FileAttributes.Normal);
                        File.Delete(files);
                    }
                    if (!Directory.EnumerateFileSystemEntries(directory).Any())
                    {
                        Directory.Delete(directory, false);
                    }
                }
                string[] filelist = Directory.GetFiles(targetDir);
                foreach (string files in filelist)
                {
                    File.SetAttributes(files, FileAttributes.Normal);
                    File.Delete(files);
                }
            });
    }
