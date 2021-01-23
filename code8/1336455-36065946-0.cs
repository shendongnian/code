        static void Main(string[] args)
        {
            TestDomain().Wait();
        }
        public static async Task<string> TestDomain()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "sso-key VUjHMntw_UyosKRMGaLXE4e3E1h29Xx:DSqM2jiJcRyXvSbLehjYUZ");
                HttpResponseMessage response = await client.GetAsync("https://api.ote-godaddy.com/v1/domains/available?domain=google.com");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    return result;
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
  
                    return response.ReasonPhrase;
                }
            }
        }
