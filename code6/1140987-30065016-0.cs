    public async Task<string> PostRawBufferManual()
    {
        string result = await Request.Content.ReadAsStringAsync();
        return result;
    }
