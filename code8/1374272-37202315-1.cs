    public static readonly DependencyProperty PeopleListProperty =
        DependencyProperty.Register("PeopleList",
        typeof(ObservableCollection<Person>),
        typeof(ViewModel));
    public ObservableCollection<Person> PeopleList
    {
        get
        {
            return GetValue(PeopleListProperty) as ObservableCollection<EmissionEntry>;
        }
        set
        {
            SetValue(PeopleListProperty, value);
        }
    }
    private ICommand _storeCommand;
    public ICommand StoreCommand
    {
        get
        {
            if (_storeCommand == null)
                _storeCommand = new MyCommandImplementation();
            return _storeCommand;
        }
    }
