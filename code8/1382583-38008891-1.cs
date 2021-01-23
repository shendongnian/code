      public class AuthenticationResponse
      {
        public string token_type { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public int expires_on { get; set; }
        public int not_before { get; set; }
        public string resource { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string id_token { get; set; }
      }
    private static async Task<AuthenticationResponse> GetAuthenticationResponse()
    {
      
    //create the collection of values to send to the POST
    
      List<KeyValuePair<string, string>> vals = new List<KeyValuePair<string, string>>();
    
      vals.Add(new KeyValuePair<string, string>("client_id", ClientId));  
      vals.Add(new KeyValuePair<string, string>("resource", ResourceId));
      vals.Add(new KeyValuePair<string, string>("username", "yxcyxc@xyxc.onmicrosoft.com"));
      vals.Add(new KeyValuePair<string, string>("password", "yxcycx"));
      vals.Add(new KeyValuePair<string, string>("grant_type", "password"));
      vals.Add(new KeyValuePair<string, string>("client_secret", Password));
    
    
      string url = string.Format("https://login.windows.net/{0}/oauth2/token", Tenant);
      using (HttpClient httpClient = new HttpClient())
      {
    
        //make the request
    httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
    //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
    //form encode the data we’re going to POST
    HttpContent content = new FormUrlEncodedContent(vals);
    //plug in the post body
    HttpResponseMessage hrm = httpClient.PostAsync(url, content).Result;
    AuthenticationResponse authenticationResponse = null;
    if (hrm.IsSuccessStatusCode)
    {
      //get the stream
      Stream data = await hrm.Content.ReadAsStreamAsync();
      DataContractJsonSerializer serializer = new 
    DataContractJsonSerializer(typeof(AuthenticationResponse));
          authenticationResponse = (AuthenticationResponse)serializer.ReadObject(data);
        }
    
        return authenticationResponse;
      }
    }
    private static async Task DataOperations(AuthenticationResponse authResult)
    {
    
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.BaseAddress = new Uri(ResourceApiId);
        httpClient.Timeout = new TimeSpan(0, 2, 0); //2 minutes
        httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
        httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.access_token);
    
        Account account = new Account();
        account.name = "Test Account";
        account.telephone1 = "555-555";
    
        string content = String.Empty;
        content = JsonConvert.SerializeObject(account, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore });
    
        //Create Entity/////////////////////////////////////////////////////////////////////////////////////
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/data/v8.0/accounts");
        request.Content = new StringContent(content);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        HttpResponseMessage response = await httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
          Console.WriteLine("Account '{0}' created.", account.name);
        }
        else
        {
          throw new Exception(String.Format("Failed to create account '{0}', reason is '{1}'."
            , account.name
            , response.ReasonPhrase));
        }
    (...)
