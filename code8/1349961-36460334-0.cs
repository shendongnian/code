    var client = new HttpClient();
    client.BaseAddress = new Uri("localhost:8080");
    string jsonData = "{\"username\":\"myusername\",\"password\":\"mypassword\"}"
    var content = new StringContent (json, Encoding.UTF8, "application/json");
	HttpResponseMessage response = await client.PostAsync("Your API Call", content);
    // this result string should be something like: "{\"token\":\"rgh2ghgdsfds\"}"
    var result = await response.Content.ReadAsStringAsync();
