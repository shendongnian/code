    public static async Task<string> ReturnAsync()
    {
        var tsc = new TaskCompletionSource<string>();
        tsc.SetResult("hello world");
        return await tsc.Task;
    } 
