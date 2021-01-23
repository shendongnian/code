    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    public string StatusText
    {
        get {return this.m_statusText;}
        set
        {
            if (value != this.m_statusText)
            {
                this.m_statusText= value;
                NotifyPropertyChanged("StatusText");
            }
        }
    }
