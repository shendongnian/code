    public static async Task<string> GetASM(string path)
        {
            string tokenVal = "d2GpEA5r8pwLRcOPxgaygPooldz2OZ2HUZzZ0YDPAOYCIiH4u5";
            Uri uriASM = new Uri(urlASM);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = uriASM })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                {
                    cookieContainer.Add(uriASM, new Cookie("token", tokenVal));
                    var getResponse = await client.GetAsync(path);
                    return await getResponse.Content.ReadAsStringAsync();
                }
            }
        }
