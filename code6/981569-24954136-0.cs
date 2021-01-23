    public static Task<Response> SendRequestAsync(Connection connection, Request request)
    {
        var tcs = new TaskCompletionSource<Response>();
        connection.BeginSendRequest(asyncResult =>
        {
            try
            {
                var c = asyncResult.AsyncState as Connection;
                var response = c.EndSendRequest(asyncResult);
                tcs.SetResult(response);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }, connection);
        return tcs.Task;
    }
