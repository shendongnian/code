    class ServerUtil
    {
        public async Task<string> ServerMessage(string query)
        {
            return await ServerMessageHelper(query);
        }
        private async Task<string> ServerMessageHelper(string query)
        {
            var baseUri = new UriBuilder("http://darksync-anarchysystems.rhcloud.com/ServletExample/ServletExample?");
            baseUri.Query = baseUri.Query.Substring(1) + query;
            var url = baseUri.Uri.ToString();
            using (var httpClient = new HttpClient(new HttpClientHandler()))
            {
                try
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                catch
                {
                    return "505";
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var username = "xxx";
            var password = "xxx";
            var s = new ServerUtil();
            var resp = s.ServerMessage("action=login&user=" + username + "&password=" + password).GetAwaiter().GetResult();
        }
    }
