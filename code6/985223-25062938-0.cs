            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
        
        using(HttpClient client = new HttpClient(handler))
       {     
          client.BaseAddress = new Uri("http://localhost:52613/api/acmeco/");
          var result = client.GetAsync("assignees/get").Result;
          string resultContent = result.Content.ReadAsStringAsync().Result;
    
          JavaScriptSerializer json_serializer = new JavaScriptSerializer();
          assignees = json_serializer.DeserializeObject(resultContent);
      }
