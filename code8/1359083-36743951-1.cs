    public void CopyFile(string sourceFilePath, string destinationFilePath)
    {
        var content = File.ReadAllBytes(sourceFilePath);
        using (new Impersonator("username", "domain", "pwd"))
        {
            File.WriteAllBytes(destinationFilePath, content);
        }
    }
