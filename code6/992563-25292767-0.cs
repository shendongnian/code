        public async Task<StandardResponse> CreateJsonNotebook(string newNotebookName)
        {
            var client = new HttpClient();
            string postData = "{name: \"" + newNotebookName + "\"}";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (IsAuthenticated)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    _authClient.Session.AccessToken);
            }
            StreamWriter requestWriter;
            var webRequest = new HttpRequestMessage(HttpMethod.Post, "https://www.onenote.com/api/v1.0/notebooks")
            {
                Content = new StringContent(postData, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response;
            response = await client.SendAsync(webRequest);
            return await TranslateResponse(response);
        }
