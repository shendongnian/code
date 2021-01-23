    public async Task<IHttpActionResult> SendAsync()
    {
        var content = new StringContent(
                jsonString,
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
    
        HttpResponseMessage response = await _httpClient.PostAsync(_url, content);
    
        // Object passed to Ok will be automatically serialized to JSON
        // if response content type is JSON (and, by default, this is the serialization
        // format in ASP.NET WebAPI)
        return Ok(new { text = "hello world" });
    }
