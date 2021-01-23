        private static async Task<Token> GetATokenToTestMyRestApiUsingHttpClient(HttpClient client)
        {
            /* this code has lots of commented out stuff with different permutations of tweaking the request  */
            /* this is a version of asking for token using HttpClient.  aka, an alternate to using default libraries instead of RestClient */
            OAuthValues oav = GetOAuthValues(); /* object has has simple string properties for TokenUrl, GrantType, ClientId and ClientSecret */
            var form = new Dictionary<string, string>
                    {
                        { "grant_type", oav.GrantType },
                        { "client_id", oav.ClientId },
                        { "client_secret", oav.ClientSecret }
                    };
            /* now tweak the http client */
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            /* try 1 */
            ////client.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");
            /* try 2 */
            ////client.DefaultRequestHeaders            .Accept            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));//ACCEPT header
            /* try 3 */
            ////does not compile */client.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            ////application/x-www-form-urlencoded
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, oav.TokenUrl);
            /////req.RequestUri = new Uri(baseAddress);
            
            req.Content = new FormUrlEncodedContent(form);
            ////string jsonPayload = "{\"grant_type\":\"" + oav.GrantType + "\",\"client_id\":\"" + oav.ClientId + "\",\"client_secret\":\"" + oav.ClientSecret + "\"}";
            ////req.Content = new StringContent(jsonPayload,                                                Encoding.UTF8,                                                "application/json");//CONTENT-TYPE header
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            /* now make the request */
            ////HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            HttpResponseMessage tokenResponse = await client.SendAsync(req);
            Console.WriteLine(string.Format("HttpResponseMessage.ReasonPhrase='{0}'", tokenResponse.ReasonPhrase));
            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Call to get Token with HttpClient failed.");
            }
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok;
        }
