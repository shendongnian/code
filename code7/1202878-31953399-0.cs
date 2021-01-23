    private async void Foo()
    {
        StreamSocket streamSocket = new StreamSocket();
        await streamSocket.ConnectAsync(new HostName("localhost"), "8888");
        IBuffer buffer = new Windows.Storage.Streams.Buffer(16);
        IInputStream inputStream = streamSocket.InputStream;
        Task<IBuffer> readTask = inputStream.ReadAsync(
            buffer,
            buffer.Capacity,
            InputStreamOptions.None).AsTask();
        var notAwait = readTask.ContinueWith(ReadMore, streamSocket);
    }
    private void ReadMore(Task<IBuffer> task, object state)
    {
        StreamSocket streamSocket = state as StreamSocket;
        if (task.Status != TaskStatus.RanToCompletion)
        {
            // TODO: Handle error.
            return;
        }
        IBuffer buffer = task.Result;
        Guid guid = new Guid(buffer.ToArray());
        Debug.WriteLine(guid);
        if (guid == Guid.Empty)
        {
            // Close socket and stop reading.
            streamSocket.Dispose();
            return;
        }
        IInputStream inputStream = streamSocket.InputStream;
        Task<IBuffer> readTask = inputStream.ReadAsync(
            buffer,
            buffer.Capacity,
            InputStreamOptions.None).AsTask();
        var notAwait = readTask.ContinueWith(ReadMore, streamSocket);
    }
