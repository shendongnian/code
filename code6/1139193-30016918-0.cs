    public string Current
    {
        get { return _current; }
        set
        {
            _current = value;
            Debug.WriteLine(_current);
            Mvx.Resolve<IMvxMainThreadDispatcher>()
               .RequestMainThreadAction(() => NotifyPropertyChanged("Current"));
        }
    }
