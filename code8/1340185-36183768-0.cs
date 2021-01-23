    readonly Stack<Action> _undo = new Stack<Action>();
    string _someProperty;
    // property to bind
    public string SomeProperty
    {
        get { return _someProperty; }
        set
        {
            var old = _someProperty; // capture old value
            _undo.Push(() =>
            {
                _someProperty = old;
                OnPropertyChanged();
            });
            _someProperty = value;
            OnPropertyChanged();
        }
    }
    void Undo()
    {
        if (_undo.Count > 0)
            _undo.Pop()();
    }
