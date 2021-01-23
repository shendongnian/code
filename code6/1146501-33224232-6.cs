    var client = new HttpClient();
    var uri = new Uri(verifyTokenEndPoint);
    var response = await client.GetAsync(uri);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
        string user_id = jObj["data"]["user_id"];
        string app_id = jObj["data"]["app_id"];
    }
