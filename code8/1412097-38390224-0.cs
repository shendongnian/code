    public string TestProperty
    {
        get
        {
            return testProperty;
        }
        set
        {
            testProperty = value;
            // If changing properties, fire your OnPropertyChanged to update UI
            OnPropertyChanged("TestProperty");
            //Here you can call a method of Model2 sating that its changed
              Model2 m2Instance = new Model2();
              m2Instance.ValueChanged();
        }
    }
