    /*
    .nuget\packages\newtonsoft.json\12.0.1
    .nuget\packages\system.net.http\4.3.4
    */
            
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
		
		
		private static async Task<Token> GetElibilityToken(HttpClient client)
        {
            string tokenUri = 
            string baseAddress = @"https://blah.blah.blah.com/token";
            string grant_type = "client_credentials";
            string client_id = "myId";
            string client_secret = "shhhhhhhhhhhhhhItsSecret";
            var form = new Dictionary<string, string>
                    {
                        {"grant_type", grant_type},
                        {"client_id", client_id},
                        {"client_secret", client_secret},
                    };
            HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok;
        }
		
		
           internal class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }		
