    using (var httpClient = new HttpClient())
    {
        try
        {
            string resultString = await httpClient.GetStringAsync(endpoint);
            var result = JsonConvert.DeserializeObject<...>(resultString.Content.ReadAsStringAsync().Result);
            return result;
        }
        catch (HttpRequestException ex)
        {
            throw ex;
        }
    }
