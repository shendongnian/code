    public ReactiveList<string> Operators
    {
        get { return _operators; }
        set { this.RaiseAndSetIfChanged(ref _operators, value); }
    }
