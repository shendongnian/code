    public void writeEmptyFile(string path, int size)
    {
        using(FileStream fs = new FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.ReadWrite))
        {
            fs.Write(new byte[size], 0, size);
        }
    }
