    public async Task ContentAction()
    {
        var jsonString = "{\"foo\":1,\"bar\":false}";
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        Response.ContentType = "application/json";
        await Response.Body.WriteAsync(data, 0, data.Length);
    }
