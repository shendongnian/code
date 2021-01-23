    public string SomeIds { get; set; }
    public string[] ParsedIds 
    {
        get 
        {
            return SomeIds.Split(',');
        }
    }
