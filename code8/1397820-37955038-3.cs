    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        HttpResponseMessage result = client.GetAsync(_url).Result;
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            RefreshToken(); /* Or reenter resource owner credentials if refresh token is not implemented */
            if (/* token refreshed, repeat the request using the new access token */)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _newAccessToken);
                result = client.GetAsync(_url).Result;
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Process the error
                }
            }
        }
        return result;
    }
