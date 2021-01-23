    public async Task<String> read()
    {
        string runStr = "";
        uint inBufferCnt = 0;
        //size of bytes to load each time.
        uint sizeToReadEachTime = 256;
        CancellationTokenSource cts = new CancellationTokenSource();
        //set timeout here.
        cts.CancelAfter(5000);
        using (reader = new DataReader(socket.InputStream))
        {
            //set the read options for the input stream to Partial.
            reader.InputStreamOptions = Windows.Storage.Streams.InputStreamOptions.Partial;
            reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            reader.ByteOrder = Windows.Storage.Streams.ByteOrder.LittleEndian;
            while (true)
            {
                try
                {
                    //add a timeout for the asynchronous load operation.
                    inBufferCnt = await reader.LoadAsync(sizeToReadEachTime).AsTask(cts.Token);
                    runStr += reader.ReadString(inBufferCnt);
                }
                catch (System.Threading.Tasks.TaskCanceledException)
                {
                    //load operation will get timeout only when there is no data available.
                    cts.Dispose();
                    break;
                }
            }
            reader.DetachStream();
        }
        return runStr;
    }
