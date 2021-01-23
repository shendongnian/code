    public int MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            // Essentially, I want to know how to tell when the code enters here from the client typing on the UI, or from the server.
            myProperty = value;
            OnPropertyChanged("MyProperty");
        }
    }
    public void OnPropertyChanged(string propertyName)
    {
        // send this property and its value to the server.
    }
    private void OnServerChangedMyProperty(int value)
    {
        myProperty = value;
        OnPropertyChanged("MyProperty");
    }    
