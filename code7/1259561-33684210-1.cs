    var response = client.PostAsync(TERMBASED_ENDPOINT,
        new StringContent(JsonConvert.SerializeObject(request).ToString(),
                          Encoding.UTF8, "application/json")).Result;
    
    var readTask = response.Content.ReadAsAsync<MyObject>();
    //other code synchronously processed
    await Task.WhenAll(readTask);
    var result = readTask.Result;
