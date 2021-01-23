        public class Client
        {           
            public async Task<string> authenticate( string username, string password )
            {
                using (var client = new HttpClient ())
                {
                    string content = null;
    
                    client.BaseAddress = new Uri ("https://example.com/api/");
                    client.DefaultRequestHeaders.Accept.Clear ();
                    client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", string.Format ("{0}:{1}", username, password));
    
                    HttpResponseMessage response = await client.PostAsync ("auth", null);
    //deserialize json, not sure if you need it as its not an object that you are returning
                    jsonstring = await response.Content.ReadAsStringAsync();
    var content = JsonConvert.DeserializeObject<string>(jsonstring);
                    return content;
                }
            }
        }
