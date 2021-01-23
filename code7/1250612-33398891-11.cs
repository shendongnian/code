    private ICollection<Inline> _inlineList;
    public ICollection<Inline> InlineList
    {
        get { return _inlineList; }
        set { Set(() => InlineList, ref _inlineList, value); }
    }
