    public async Task<T> MakeHttpClientRequestASync<T>(string requestUrl, string authenticationToken,
                    Dictionary<string, string> requestContent, HttpMethod verb, Action<Exception> error)
    {
         var httpClient = new HttpClient();
        //// add access token to AuthenticationHeader
         efaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Access-Token",authenticationToken);
         HttpResponseMessage response;
            
         var returnVal = default(T);
            
         try
          {
           if (verb == HttpMethod.Post)
            {
             response = await httpClient.PostAsync(requestUrl, new FormUrlEncodedContent(requestContent));
            }
            else
            {
               response = await httpClient.GetAsync(requestUrl);
            }
            
            var resultString = await response.Content.ReadAsStringAsync();
            //// DeserializeObject using Json.net
            returnVal = JsonConvert.DeserializeObject<T>(resultString);
           }
           catch (Exception ex)
           {
             error(ex);
           }
            
        return returnVal;
    }
