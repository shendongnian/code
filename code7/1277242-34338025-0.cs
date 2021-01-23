    private HttpResponseMessage GetResponse(HttpMethod method, string requestUri, object value)
    {
        HttpRequestMessage message = new HttpRequestMessage(method, requestUri);
        if (Login != null)
        {
            message.Headers.Add("Authorization", "Basic " + Login.AuthenticatieString);
        }
        if (value != null)
        {
            string jsonString = JsonConvert.SerializeObject(value);
            HttpContent content = new StringContent(jsonString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            message.Content = content;
        }
        #if DEBUG
        ServicePointManager.ServerCertificateValidationCallback =
         delegate (object s, X509Certificate certificate,
         X509Chain chain, SslPolicyErrors sslPolicyErrors)
         { return true; };
        #endif
        HttpResponseMessage response = Client.SendAsync(message).Result;
        return response;
    }
