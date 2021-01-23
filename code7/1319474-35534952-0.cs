    // C# 6.0, read only property
    public BindingList<string> Titles { get; } = new BindingList<string>();
    // C# 5.0 and older
    private readonly BindingList<string> titles = new BindingList<string>();
    public BindingList<string> Titles { get { return titles; } }
