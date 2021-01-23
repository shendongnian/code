    using (var client = new System.Net.Http.HttpClient())
    {
        client.BaseAddress = new System.Uri("http://localhost:31573/api/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var obj = new MyClass { Value = 3 };
        var data = JsonConvert.SerializeObject(obj);
        StringContent queryString = new StringContent(data, Encoding.UTF8, "application/json");
        var paramsValue = queryString.ReadAsStringAsync().Result;
        var response = client.PostAsync("Test/PostMethod",  queryString).Result;
        var textResponse = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<MyClass>(textResponse);
    }
