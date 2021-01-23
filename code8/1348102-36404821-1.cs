    public DateTime Date
    {
        get { return date; }
        set
        {
            date = value;
            PropertyChanged(this, new PropertyChangedArg("Date"); 
        }
    } 
