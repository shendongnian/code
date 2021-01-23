    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int retVal = p.Process().Result;            
        }
        private async Task<int> Process()
        {
            string url = "http://bi.abhi.com/testweb/";
            using (HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Add("Accept", "application/json; odata=verbose");
                string digest = await GetDigest(client);
                Console.WriteLine("Digest " + digest);
                try
                {
                    await CreateFolder(client, digest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return 0;
        }
        private object CreateRequest(string folderPath)
        {
            var type = new { type = "SP.Folder" };
            var request = new { __metadata = type, ServerRelativeUrl = folderPath };
            return request;
        }
        private async Task CreateFolder(HttpClient client, string digest)
        {
            client.DefaultRequestHeaders.Add("X-RequestDigest", digest);
            var request = CreateRequest("foo");
            string json = JsonConvert.SerializeObject(request);
            StringContent strContent = new StringContent(json);
            strContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            HttpResponseMessage response = await client.PostAsync("_api/web/getfolderbyserverrelativeurl('test/test123/')/folders", strContent);
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.ReasonPhrase);
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }
        public async Task<string> GetDigest(HttpClient client)
        {
            string retVal = null;
            string cmd = "_api/contextinfo";                       
            HttpResponseMessage response = await client.PostAsJsonAsync(cmd, "");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JToken t = JToken.Parse(content);
                retVal = t["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
            }
            return retVal;
        }
    }
