    class ServerUtil
    {
        public string ServerMessage(string query)
        {
            return ServerMessageHelperAsync(query).GetAwaiter().GetResult();
        }
        public async Task<string> ServerMessageAsync(string query)
        {
            return await ServerMessageHelperAsync(query);
        }
        private async Task<string> ServerMessageHelperAsync(string query)
        {
            var baseUri = new UriBuilder("http://darksync-anarchysystems.rhcloud.com/ServletExample/ServletExample");
            baseUri.Query = query;
            using (var httpClient = new HttpClient(new HttpClientHandler()))
            {
                try
                {
                    using (var response = await httpClient.GetAsync(baseUri.Uri))
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
            //var resp = s.ServerMessageAsync("action=login&user=" + username + "&password=" + password).GetAwaiter().GetResult();
            var resp = s.ServerMessage("action=login&user=" + username + "&password=" + password);
        }
    }
