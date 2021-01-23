    public async Task<IEnumerable<DataContainer>> GetDataForTarget(string id)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(new Uri(Host),
            string.Format("api/Data?id={0}", id)));
            var response = await Client.SendAsync(requestMessage);
            //etc...
    }
