    public void WhenIBlablablabla(string url, string request, Type type)
    {
        // Do stuff
    }
    [When(@"When I call the URL with the RequestObject and Type (.*)(.*)(.*)")]
    public void WhenICallTheURLWithTheRequestObjectAndType(string url, string request, string type)
    {
        Type systemType = Type.GetType(type);
        WhenIBlablablabla(url, request, systemType);
    }
