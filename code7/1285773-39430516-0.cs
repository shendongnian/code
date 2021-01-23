    String yourURL = "https://www.google.com.br";
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://www.googleapis.com");
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    var response = client.GetAsync($"/pagespeedonline/v3beta1/mobileReady?url={yourURL }&key=AIzaSyArsacdp79HPFfRZRvXaiLEjCD1LtDm3ww").Result;
    string json = response.Content.ReadAsStringAsync().Result;
    JObject obj = JObject.Parse(json);
    bool isMobileFriendly = obj.Value<JObject>("ruleGroups").Value<JObject>("USABILITY").Value<bool>("pass");
