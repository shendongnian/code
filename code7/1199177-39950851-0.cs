            public static async Task<T> Post<T>(string controller, string method, string accessToken, string bodyRequest) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var stringContent = new StringContent(bodyRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{Constants.ApiBaseUrl}/api/{controller}/{method}", stringContent);
                if (response.IsSuccessStatusCode)
                    return response.Content as T;
            }
            return default(T);
        }
