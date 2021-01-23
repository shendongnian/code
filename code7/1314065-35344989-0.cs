    public string ReadDocument(string fileName)
    {
        if (File.Exists(fileName))
        {
            return File.ReadAllText(fileName);
        }
        else
        {
           //...
        }
    }
