    public Thing SelectedThing
    {
        get { return _selectedThing; }
        set
        {
            _selectedThing = value;
            NotifyOfPropertyChange(() => SelectedThing);
            
            _eventAggregator.PublishOnUIThread(SelectedThing);
        }
    }
