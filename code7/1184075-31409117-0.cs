    public string Get()
    {
        ActionContext.Response.Headers.TransferEncodingChunked = true;
        // ...
    }
