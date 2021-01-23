    public async Task ContentAction()
    {
        var jsonString = "{\"foo\":1,\"bar\":false}";
        Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
        await Response.WriteAsync(jsonString, Encoding.UTF8);
    }
