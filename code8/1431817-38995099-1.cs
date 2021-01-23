    public static async Task<string[]> SendToAllIps(string req)
    {
        var tasks = _allIps.Select(ip => SendRequest(new Uri(ip + req)));
        return await Task.WhenAll(tasks);
    }
