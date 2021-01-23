    public async Task<string> ReceiveString()
    {
        NetworkStream netStream = _client.GetStream(); //Using _client instead of _socket
        StreamReader streamReader = new StreamReader(netStream);
        string result = await streamReader.ReadLine(); //Reading the stream until we find a newline
        return result;
    }
