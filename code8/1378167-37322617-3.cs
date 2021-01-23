    public async Task<List<SubscriberHistory>> GetSubscriberHistory()
    {
        List<SubscriberHistory> list = new List<SubscriberHistory>();
        var result = await client.GetAsync("http://myhost/mypath"); //Your code here
        return list;
    }
