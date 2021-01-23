    public async Task<object []> ApiCommand(string api, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Variables.apiURL + api);
            httpWebRequest.ContentType = "text/plain; charset=utf-8";
            httpWebRequest.Method = "POST";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = await client.PostAsync(Variables.apiURL + api, new StringContent(json, Encoding.UTF8, "application/json"));
                return new[] {response.StatusCode.ToString(), await response.Content.ReadAsStringAsync()};
            }
            catch (Exception ex)
            {
                return new[] {"EXCEPTION", ex.ToString()};
            }
        }
