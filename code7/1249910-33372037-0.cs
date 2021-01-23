    private void FileCheck(string fp)
    {        
        if (File.Exists(fp))
        {
            File.Delete(fp);
            File.Create(fp);
        }
    }
