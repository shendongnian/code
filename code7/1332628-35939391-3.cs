    using System.Net.Http;
    public string sendPostRequest(string URI, dynamic content)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://yourBaseAddress");
            var valuesAsJson = JsonConvert.SerializeObject(content);
            HttpContent contentPost = new StringContent(valuesAsJson, Encoding.UTF8, "application/json");
            var result = client.PostAsync(URI, contentPost).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
