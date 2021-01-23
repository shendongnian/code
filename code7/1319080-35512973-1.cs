    [WebMethod]
    public static string checkQuery(string sql)
    {
        string encryptingIT = new AES().Encrypt(sql);
        string result = await q(encryptingIT);
        return result;
    }
    public static async Task<string> q(string encryptingIT)
    {
        var client = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(new Product { query = encryptingIT, empImg = false }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await client.PostAsync("http://dev-zzzz/newWS/theQ", content);
    
        var value = await response.Content.ReadAsStringAsync();
    
        return value;
    }
