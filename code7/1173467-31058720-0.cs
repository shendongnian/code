    public ObservableCollection<SomeClass> ListProperty
    {
        get
        {
            //return something
        }
        set
        {
            //set something
        }
    }
    public SomeClass DisplayProperty
    {
        get
        {
            //returns something involving ListProperty
        }
        set
        {
            //set something
            OnPropertyChanged("DisplayProperty");
        }
    }
    private void AddSomeItem(SomeClass item)
    {
        //any extra code
        ListProperty.Add(item);
        OnPropertyChanged("DisplayProperty");
    }
