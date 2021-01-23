    using(WebApp.Start(url: "http://localhost:9000/", startup: startup.Configuration))
    using(var client = new System.Net.Http.HttpClient))
    {
       client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
       using(System.Net.Http.HttpResponseMessage response = client.GetAsync(ResourceUnderTest.ToString()).Result)
       {
          if(response.StatusCode != System.Net.HttpStatusCode.OK){Assert.Fail("you suck");}
    
          String content = response.Content.ReadAsStringAsync().Result;
          DateTime actual = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTime>(token);
          Assert.AreEqual(actual, expected);
       }
    }
    ► Passed Tests (1)
       ✔ FluxCapacitor
