    public event PropertyChangedEventHandler PropertyChanged;
    private string uriName = null;
    public string UriName
    {
        get { return this.uriName; }
        set { this.SetField(ref this.uriName, value); }
    }
    protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(field, value))
        {
            field = value;
            RaiseEventPropertyChanged(propertyName);
        }
    }
    private void RaiseEventPropertyChanged(string propertyName)
    {
        var tmpEvent = this.PropertyChanged;
        if (tmpEvent != null)
        {
            tmpEvent(this, new PropertyChangedEventArgs(propertyName));
        }
    }
