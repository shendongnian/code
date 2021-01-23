    public static Task<int> ReadTask(this Stream stream, 
        byte[] buffer, int offset, int count, object state)
    {
        var tcs = new TaskCompletionSource<int>();
        stream.BeginRead(buffer, offset, count, ar =>
        {
            try { tcs.SetResult(stream.EndRead(ar)); }
            catch (Exception exc) { tcs.SetException(exc); }
        }, state);
        return tcs.Task;
    }
    
