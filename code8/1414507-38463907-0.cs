    private string _label1;
    public string Label1
    {
        get { return _label1; }
        set
        {
            if(_label1 == value) return;
            _label1 = value;
            OnPropertyChanged("Label1");
        }
    }
    //implement the INotifyPropertyChanged interface
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string prop)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
