    private Stream stream;
    private Task currentTask;
    public async void SendAsync(byte[] data)
    {
        currentTask = WriteAsyncWhenStreamAvailable(data);
        await currentTask;
    }
    private async Task WriteAsyncWhenStreamAvailable(byte[] data)
    {
        if (currentTask != null)
            await currentTask.ConfigureAwait(false);
        await WriteAsync(data);
    }
    public async Task WriteAsync(byte[] data)
    {
        await stream.WriteAsync(data.Length).ConfigureAwait(false);
        await stream.WriteAsync(data).ConfigureAwait(false);
        await stream.FlushAsync().ConfigureAwait(false);
    }
