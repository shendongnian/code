    using (var client = new HttpClient())
    {
        string content = "{\"a\":\"b\"}";
        StringContent httpContent = new StringContent(content);
        var response = await client.PostAsync("$URL", httpContent);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            // Show response. 
        }
        else
        {
            // Show error.
        }
    }
