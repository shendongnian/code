    public YourDataType YourSelectedItemProperty
    {
        get { return yourSelectedItemProperty; }
        set
        {
            if (isOkToChangeTabItem)
            {
                yourSelectedItemProperty = value;
                NotifyPropertyChanged("YourSelectedItemProperty");
            }
        }
    }
