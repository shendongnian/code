    set
    {
        _first = value;
        _sum = _first + _second;
        OnPropertyChanged("First"); //Update bindings to First
        OnPropertyChanged("Sum"); //Update bindings to Sum
    }
