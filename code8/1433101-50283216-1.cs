    [Route("valueparamfrombody"), HttpPost]
    public void PostWithParam2([FromBody] JObject value1)
    {
    }
    var req = new
    {
       value1 = "1"
    };
    var obj = JsonConvert.SerializeObject(req);
    content = new StringContent(obj);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");            
    result = client.PostAsync(baseAddress + "api/valueparamfrombody", content).Result;
