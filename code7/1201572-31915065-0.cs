    private byte[] GetFileBytes(string myPath)
    {
        FileInfo file = new FileInfo(myPath);
        byte[] bytes = new byte[file.Length];
        using (FileStream fs = file.OpenRead())
        {
            fs.Read(bytes, 0, bytes.Length);
        }
        return bytes;
    }
