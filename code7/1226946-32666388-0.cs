    public HttpResponseMessage Hello()
    {
        var res = new HttpResponseMessage(HttpStatusCode.OK);
        res.Content = new StringContent("hello", Encoding.UTF8, "text/plain");
        return res;
    }
