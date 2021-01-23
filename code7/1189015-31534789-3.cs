    if (File.Exists(filePath))
    {
        FileInfo myfile = new FileInfo(filePath);
        if(IsLocked(myfile))
        {
            File.Create(filePath).Close();
            File.Delete(filePath);
            eLog.WriteEntry("file deleted");
        }
        else
        {
            File.Delete(filePath);
            eLog.WriteEntry("file deleted");
        }
    }
