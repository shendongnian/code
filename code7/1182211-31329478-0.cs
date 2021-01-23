    public async static Task<string> PostURL(string uri, List<KeyValuePair<string, string>> pairs)
    {
        try
        {
            var content = new FormUrlEncodedContent(pairs);
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                string resp = await response.Content.ReadAsStringAsync();
                return resp;
            }
            else
                return "Failed";
        }
        catch (AggregateException e)
        {
            return e.Message;
        }
    }
