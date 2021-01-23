    //[Inject] //remove this attribute
    public T TextParser { get; set; }
    public SimpleTextIndex(T parser, string text = "")
    {
        TextParser = parser;
        ...
    }
