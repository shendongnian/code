    public static async Task<string[]> SendToAllIps(string req)
    {
        var tasks = _allIps.Select(ip => SendRequest(new Uri(ip + req)));
        await Task.WhenAll(tasks);
    }
