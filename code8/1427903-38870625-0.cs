    private readonly object _lock = new object()
    public void SaveToFile(string fileName, byte[] data)
    {
        lock(_lock)
        {
            using(FileStream sw = FileStream.Create(fileName))
            {
                sw.Write(data, 0, data.Length);
            }
        }
    }
