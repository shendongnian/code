    public static string AddPostRequestBody<T>(this HttpClient httpclient, string requestUrl, T classObject)
        {
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(classObject);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(jsonBody);
            string requestBody = requestMessage.Content.ReadAsStringAsync().Result;
            return requestBody;           
        }
    
