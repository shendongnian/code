    public static class HttpClientExt
    {
        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUrl, T theObj)
        {
            var stringContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(theObj),
                System.Text.Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUrl, stringContent);
        }
    }
