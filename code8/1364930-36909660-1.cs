    public delegate void DataTransferringDelegate(string name, long transBytes, long totalBytes);
    public event DataTransferringDelegate dataTransferring;
    public void upload(string fileName, bool resume)
    {
        long length;
        long num2 = 0L;
        // some code removed here
        dataTransferring(fileName, num2, length);
    }
