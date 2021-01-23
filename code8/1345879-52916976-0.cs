    ...
    FireAndForget().Wait();
    ...
    
    private async Task FireAndForget()
        {
            using (var httpClient = new HttpClient())
            {
                HttpCookie cookie = this.Request.Cookies["AuthCookieName"];
                var authToken = cookie["AuthTokenPropertyName"] as string;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                using (var response = await httpClient.GetAsync("http://localhost/api/FireAndForgetApiMethodName"))
                {
                    //will throw an exception if not successful
                    response.EnsureSuccessStatusCode();
                }
            }
        }
