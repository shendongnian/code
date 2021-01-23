    internal void UnzipProject()
    {
        if (Directory.Exists(SourceDir))
        {
            DirectoryInfo di = new DirectoryInfo(SourceDir);
  
            foreach (FileInfo file in di.GetFiles())
                file.Delete();
    
            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }
    
        if (File.Exists(zipFile))
            ZipFile.ExtractToDirectory(zipFile, SourceDir);
    
        else
        {
            if (Directory.Exists(SourceDir))
                Directory.Delete(SourceDir, true);
        }
    }
