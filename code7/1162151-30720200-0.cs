    public DateTime Time
    {
        get { return this.model.DateTime; }
        set
        {
            this.model.DateTime = value;
            NotifyPropertyChanged();
        }
    }
 
