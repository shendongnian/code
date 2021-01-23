    public async Task<HttpResponseMessage> Register()
    {
        HttpRequestMessage request = new HttpRequestMessage
        {
            RequestUri = new Uri( _http.BaseAddress, "account/register/" ),
            Method = HttpMethod.Post,
            Content = new StringContent( "{\"Email\": \"email@yahoo.com\",\"Password\": \"Password!1\",\"ConfirmPassword\": \"Password!1\"}",
            Encoding.UTF8,
            _contentType
            ),
        };
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _http.SendAsync( request, CancellationToken.None );
            }
            catch (Exception e)
            {
                Debugger.Break();
            }
        return response;
    }
