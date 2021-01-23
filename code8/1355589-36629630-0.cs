    static async Task RunAsync()
            {
                using (var client = new HttpClient())
                {
                   client.BaseAddress = new Uri("http://localhost:52967/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    //setup login data
                    var username = "support1@gmail1.com";
                    var password = "Testing1!";
                    var formContent = new FormUrlEncodedContent(new[]
                    {
     new KeyValuePair<string, string>("grant_type", "password"),
     new KeyValuePair<string, string>("username", username),
     new KeyValuePair<string, string>("password", password),
     });
                    //send request
                    HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);
    
                    //get access token from response body
                    var responseJson = await responseMessage.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(responseJson);
                    var token = jObject.GetValue("access_token").ToString();
     
     
                }
