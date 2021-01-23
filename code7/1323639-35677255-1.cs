    [HttpGet]
    [ActionName("Index")]
    public string Get()
    {
        return _appsettings.Value.ApplicationName;
    }
