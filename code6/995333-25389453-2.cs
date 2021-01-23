    public static Task<int> WhenRead(
        this NetworkStream stream,
        byte[] buffer,
        int offset,
        int size)
    {
        var tcs = new TaskCompletionSource<int>();
        stream.BeginRead(buffer, offset, size, result =>
        {
            tcs.TrySetResult(stream.EndRead(result));
        }, null);
        return tcs.Task;
    }
