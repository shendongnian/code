    async Task<string> PostDataAsync(Dictionary<string, string> postData)
    {
        var httpContent = new FormUrlEncodedContent(postData);           
        var response = await client.PostAsync("/mydata", httpContent).ConfigureAwait(false); 
        var responsecode = (int)response.StatusCode; 
        if (response.IsSuccessStatusCode)
        {
            var responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBodyAsText;
        }
        else
        {
           return responsecode +" " +response.ReasonPhrase; 
        }
    }
