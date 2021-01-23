    public string SomeIds { get; set; }
    public string[] ParsedIds 
    {
        get 
        {
            return !string.IsNullOrEmpty(SomeIds) ? SomeIds.Split(',') : 
                                                    Enumerable.Empty<string>.ToArray();
        }
    }
