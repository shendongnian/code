    private string _endorseImageLinksDelimited;
    public string EndorseImageLinksDelimited
    {
        get { return _endorseImageLinksDelimited; }
        set
        {
            _endorseImageLinksDelimited = value;
            EndorseImageLinks = value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
    public IEnumerable<string> EndorseImageLinks { get; private set; } = Enumerable.Empty<string>();
