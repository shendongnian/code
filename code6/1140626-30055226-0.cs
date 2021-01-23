    <pre>
    static async Task<string> WsGetResponseString(WebRequest webreq, CancellationToken cancelToken)
    {
        cancelToken.Register(webreq.Abort);
        using (var response = await webReq.GetResponseAsync())
        using (var stream = response.GetResponseStream())
        using (var destStream = new MemoryStream())
        {
            await stream.CopyToAsync(destStream, 4096, cancelToken);
            return Encoding.UTF8.GetString(destStream.ToArray());
        }
    }
    </pre>
