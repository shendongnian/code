    var targetDir = @"D:\test";
    var zipFile = @"D:\test.zip"; 
    using (ZipArchive zipArchive = ZipFile.Open(zipFile, ZipArchiveMode.Read)) 
          zipArchive.AddDirectory(targetDir, "test");
    public static class ExtensionMethods;
        {
    
            public static void AddDirectory(this ZipArchive zip, string targetDir, string subDir = null, CompressionLevel compressionLevel = CompressionLevel.Optimal)
            {
                var ogrDir = targetDir.Replace("/", "\\");
                if (!ogrDir.EndsWith("\\"))
                    ogrDir = ogrDir + "\\";
    
                if (subDir == null)
                    subDir = "";
                else
                {
                    subDir = subDir.Replace("/", "\\");
                    if (subDir.StartsWith("\\"))
                        subDir = subDir.Remove(0, 1);
    
                    if (!subDir.EndsWith("\\"))
                        subDir = subDir + "\\";
                }
                Action<string> AddDirectoryAndSubs = null;
                AddDirectoryAndSubs = delegate (string _targetDir)
                {
                    string[] files = Directory.GetFiles(_targetDir);
                    foreach (string file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        zip.CreateEntryFromFile(fileInfo.FullName, subDir + (fileInfo.Directory.ToString() + "\\").Replace(ogrDir, "") + fileInfo.Name, compressionLevel);
                    }
    
                    string[] dirs = Directory.GetDirectories(_targetDir);
                    foreach (string dir in dirs)
                        AddDirectoryAndSubs(dir);
                };
    
                AddDirectoryAndSubs(targetDir);
            }
    
        }
