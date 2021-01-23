    private ObservableCollection<string> ocEvents = new ObservableCollection<string>();
    public ObservableCollection<string> OcEvents
    {
        get { return ocEvents; }
        set
        {
            if (Equals(value, ocEvents)) return;
            ocEvents = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator] // Comment out if you don't have R#
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
