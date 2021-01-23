    public void CopyFile(string sourceFullFileName,string targetFullFileName)
    {
        var fileInfo = new FileInfo(sourceFullFileName);
    
        try
        {
            using (var file = new FileStream(sourceFullFileName, FileMode.Open, FileAccess.Read))
            {
                 byte[] bytes = new byte[file.Length];
                 file.Read(bytes, 0, (int)file.Length);
                 ms.Write(bytes, 0, (int)file.Length);
             }
            using (new Impersonator("username", "domain", "pwd"))
            {
                 using (var file = new FileStream(Path.Combine(targetFullFileName, fileInfo.Name), FileMode.Create, FileAccess.Write))
                 {
                       byte[] bytes = new byte[ms.Length];
                       ms.Read(bytes, 0, (int)ms.Length);
                       file.Write(bytes, 0, bytes.Length);
                       ms.Close();
                 }
            }
        }
        catch (IOException)
        {
            throw;
        }
    }
