    var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var anonString = new { name = "test name" };
    var json = JsonConvert.SerializeObject(anonString);
    await client.PutAsync("URL", new StringContent(json)).ConfigureAwait(false);
