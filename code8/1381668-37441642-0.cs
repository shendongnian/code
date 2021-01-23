    [Produces("text/plain")]
    public string Tunnel()
    {
        Response.Headers.Add("Cache-Control", "no-cache");
        return "blablabla";
    }
