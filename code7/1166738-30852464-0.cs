    public Task<string> GetAnswerAsync(string question)
    {
        var tcs = new TaskCompletionSource<string>();
        try
        {
            string answer = Lookup[question];
            tcs.SetResult(answer);
            return tcs.Task;
        }
        catch (Exception e)
        {
            tcs.SetException(e);
            return tcs.Task;
        }
    }
