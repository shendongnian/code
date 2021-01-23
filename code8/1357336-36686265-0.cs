    using (ZipFile zipFile = new ZipFile())
    {
        zipFile.Password = "asd";
        zipFile.Encryption = EncryptionAlgorithm.PkzipWeak;          
        // Adding folders in the base directory
        foreach (var item in Directory.GetDirectories(filename))
        {
            string folderName = new DirectoryInfo(item).Name;
            zipFile.AddDirectory(item, folderName);
        }
        // Adding files in the base directory
        foreach (string file in Directory.GetFiles(filename))
        {
            zipFile.AddFile(file); 
        }
        zipFile.Save(zipPath);
    }
