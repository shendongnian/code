    var client = new HttpClient();
    var content = new StringContent(JsonConvert.Serialize(new { username = "myusername", password = "mypass" }));
    var result = await client.PostAsync("localhost:8080", content).ConfigureAwait(false);
    if (result.IsSuccessStatusCode)
    {
        var tokenJson = await result.Content.ReadAsStringAsync();
    }
