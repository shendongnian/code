    public ObservableCollection<Nation> Nation
    {
        get
        {
            _nations = new ObservableCollection<Nation>(_nations.GroupBy(x => x.League).SelectMany(x => x.Take(1)));
            return _nations;
        }
    }
