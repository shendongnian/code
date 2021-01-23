    public string TimeMethod1
    {
            get { return timeMethod1; }
            set
            {
                timeMethod1 = value;
    
                NotifyPropertyChanged("TimeMethod1");
            }
    }
