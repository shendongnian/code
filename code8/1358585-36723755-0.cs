    [HttpGet]
    public string test(string echoText)
    {
        // Not authorized
        if (echoText == "403")
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
        else
            return echoText;
    }
