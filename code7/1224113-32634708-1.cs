    // backing field
    private ObservableCollection<Employee> someEmployee =
        new ObservableCollection<Employee>(PopulateObject());
    // property
    public ObservableCollection<Employee> SomeEmployee
    {
        get { return someEmployee; }
    }
