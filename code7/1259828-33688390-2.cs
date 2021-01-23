    public HttpResponseMessage Get()
    {
        string result = "Your text";
        var resp = new HttpResponseMessage(HttpStatusCode.OK);
        resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
        return resp;
    }
