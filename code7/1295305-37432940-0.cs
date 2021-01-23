    public async Task<HttpCookie> AuthenticateAsync()
    {
        var filter = new HttpBaseProtocolFilter();
        using (var client = new HttpClient(filter))
        {
            var authDetails = BuildJsonAuthDetails();
            var authResult = await client.PostAsync(new Uri(BaseUrl + "/auth/login"), authDetails);
            authResult.EnsureSuccessStatusCode();
            return filter.CookieManager.GetCookies(new Uri(BaseUrl + "/auth/login")).FirstOrDefault(x => x.Name == ".ASPXAUTH");
        }
    }
