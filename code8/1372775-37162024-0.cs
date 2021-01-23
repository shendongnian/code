    public MyViewModel(type enumType)
    {
        SourceForItems = Enum.GetValues(enumType);
    }
    
    public IEnumerable SourceForItems { get; private set; }
