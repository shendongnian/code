    public async Task<string> ReadResultAsync(Task<HttpResponseMessage> responseTask)
    {
        var response = await responseTask;
        var responsecode = (int)response.StatusCode; 
        if (response.IsSuccessStatusCode)
        {
            var responseBodyAsText = await response.Content.ReadAsStringAsync();
            return responseBodyAsText;
        }
        else
        {
            return responsecode + " " + response.ReasonPhrase; 
        }
    }
