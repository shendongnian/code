    public async Task<string> PostData(string resourcePath, Object o, Boolean isCompleteUrl = false, int timeoutMinutes = -1)
    {
        using (var client = new HttpClient())
        {
            if (timeoutMinutes > 0)
            {
                client.Timeout = new TimeSpan(0,timeoutMinutes,0);
            }
            var useUrl = isCompleteUrl ? resourcePath : ApiBase + resourcePath;
            var response = await client.PostAsJsonAsync(useUrl, o);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return "";
        }
    }
