    using (HttpClient client = new HttpClient())
    {                
        var request = new StringContent(
            JsonConvert.SerializeObject(this.view.Message), 
            Encoding.UTF8, 
            "application/json");
        var response = client.PostAsync(
            new Uri("http://localhost:8080/Publisher/Send"), 
            request);
        var result = response.Result;
        view.Message = result.ToString();
    }
