    protected async Task<string> ReadTextAsync(string Url, int TimeOutSec)
    {
        try
        {
            using (HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(TimeOutSec) })
            {
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
                using (HttpResponseMessage _responseMsg = await _client.GetAsync(Url))
                {
                    using (HttpContent content = _responseMsg.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }
        catch { throw; }
    }
