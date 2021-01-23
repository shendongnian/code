    public double CurrentProgress
    {
        get { return currentProgress; }
        set
        {
            currentProgress = value;
            NotifyPropertyChanged("CurrentProgress");
            YourMethod(value);
        }
    }
