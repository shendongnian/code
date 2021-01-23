    public Stream GetResults()
    {
        // Begin filling the pipe with data on a background thread
        var pipeStream = new CircularBufferPipeStream();
        Task.Run(() => WriteResults(pipeStream));
        // Return pipe stream for immediate usage by client
        // Note: client is responsible for disposing of the stream after reading all data!
        return pipeStream;
    }
    
    // Runs on background thread, filling circular buffer with data
    void WriteResults(CircularBufferPipeStream stream)
    {
        IFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, GetItemsFromTable1());
        formatter.Serialize(stream, GetItemsFromTable2());
        formatter.Serialize(stream, GetItemsFromTable3());
        formatter.Serialize(stream, GetItemsFromTable4());
        // Indicate that there's no more data to write
        stream.CloseWritePort();
    }
