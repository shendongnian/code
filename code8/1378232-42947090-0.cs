     class Program
        {
            private static HttpClient _client;
            static void Main(string[] args)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                _client = new HttpClient ();
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                var response = _client.GetAsync("https://pincode.saratchandra.in/api/pincode/125112").Result;
            }
        }
