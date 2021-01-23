    private string _linksDelimited;
    public string LinksDelimited
    {
        get { return _linksDelimited; }
        set
        {
            _linksDelimited = value;
            Links = value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
    public IEnumerable<string> Links { get; private set; } = Enumerable.Empty<string>();
