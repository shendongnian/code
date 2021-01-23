    private ICollection<Inline> _inlineList;
        
    public ICollection<Inline> InlineList
    {
        get
        {
            return _inlineList;
        }
        set
        {
            _inlineList = value;
            RaisePropertyChanged("InlineList");
        }
    }
