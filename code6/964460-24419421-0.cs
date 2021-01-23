    // Implement INotifyPropertyChanged interface properly here
    private Dictionary<string, Pet> yourProperty = new Dictionary<string, Pet>();
    public Dictionary<string, Pet> YourProperty
    {
        get { return yourProperty; }
        set
        {
            yourProperty = value;
            NotifyPropertyChanged("YourProperty");
        }
    }
    private KeyValuePair<string, int> yourSelectedProperty;
    public KeyValuePair<string, int> YourSelectedProperty
    {
        get { return yourSelectedProperty; }
        set
        {
            yourSelectedProperty = value;
            NotifyPropertyChanged("YourSelectedProperty");
        }
    }
