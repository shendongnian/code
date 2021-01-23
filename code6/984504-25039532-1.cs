    public class ApiCaller
    {    
        /*
          this is the repository that can wrap calls to the API
          if you have many different types of object returned
          from the API it's worth considering making this generic
        */
        HttpClient client;
        public SomeClass Get()
        {
            SomeClass data;
            string url = "http://example.info/feeds/feed.aspx?alt=json-in-script";
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<SomeClass>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return data;
        }
    }
