        using Newtonsoft.Json;
        using System.Net.Http.Formatting; //Add reference to project.
        static void Main(string[] args)
        {
            string email = "test@outlook.com";
            string password = "Password@123x";
            HttpResponseMessage lresult = Login(email, password);
            if (lresult.IsSuccessStatusCode)
            {
            // Get token info and bind into Token object.           
                var t = lresult.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
            }
            else
            {
	            // Get error info and bind into TokenError object.
                // Doesn't have to be a separate class but shown for simplicity.
                var t = lresult.Content.ReadAsAsync<TokenError>(new[] { new JsonMediaTypeFormatter() }).Result;                
            }
        }
        // Posts as FormUrlEncoded
        public static HttpResponseMessage Login(string email, string password)
        {
            var tokenModel = new Dictionary<string, string>{
                {"grant_type", "password"},
                {"username", email},
                {"password", password},
                };
				
            using (var client = new HttpClient())
            {
                // IMPORTANT: Do not post as PostAsJsonAsync.
                var response = client.PostAsync("http://localhost:53007/token",
                    new FormUrlEncodedContent(tokenModel)).Result;
                return response;
            }
        }
		
		  public class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
            [JsonProperty("userName")]
            public string Username { get; set; }
            [JsonProperty(".issued")]
            public DateTime Issued { get; set; }
            [JsonProperty(".expires")]
            public DateTime Expires { get; set; }
        }
        
        public class TokenError
        {            
            [JsonProperty("error_description")]
            public string Message { get; set; }
            [JsonProperty("error")]
            public string Error { get; set; }
        }
