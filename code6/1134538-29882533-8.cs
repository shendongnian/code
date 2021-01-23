    public string ChangedProperty {
        get { return _changedProperty; }
        set {
                _changedProperty = value;
                NotifyPropertyChanged();
            }
    }
