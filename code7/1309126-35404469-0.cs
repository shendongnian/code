    public async Task<string> httpClient(object param, Uri targetUri, string key)
        {
            using(HttpClient client = new HttpClient())
            {
                string jsonData = JsonConvert.SerializeObject(param);
                FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(key, jsonData)
                });
                HttpResponseMessage response = await client.PostAsync(targetUri, content);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
