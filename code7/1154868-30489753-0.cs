    public async Task<ParsedHtml> TryParseHtml(
        string untrustedHtml,
        CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<ParsedHtml>();
        var thread = new Thread(() =>
        {
            ParsedHtml result = ParseHtml(untrustedHtml);
            tcs.TrySetResult(result);
        });
        thread.Start();
        using (cancellationToken.Register(() => tcs.TrySetCanceled()))
        {
            try
            {
                return await tcs.Task;
            }
            catch (OperationCanceledException)
            {
                thread.Abort();
                throw;
            }
        }
    }
