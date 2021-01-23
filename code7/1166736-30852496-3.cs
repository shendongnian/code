    public async Task<HttpResponseMessage> SendRequestAsync(string adaptiveUri, string xmlRequest)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            StringContent httpConent = new StringContent(xmlRequest, Encoding.UTF8);
            HttpResponseMessage responseMessage = null;
            try
            {
                 responseMessage = await httpClient.PostAsync(adaptiveUri, httpConent);
            }
            catch (Exception ex)
            {
                if (responseMessage == null)
                { 
                    responseMessage = new HttpResponseMessage();
                }
                responseMessage.StatusCode = HttpStatusCode.InternalServerError;
                responseMessage.ReasonPhrase = string.Format("RestHttpClient.SendRequest failed: {0}", ex);
            }
            return responseMessage;
        }
    }
