    public OperationCommand AddPerson { get; set; }
    public string _currentPerson;
    
    public MainViewModel()
    {
        People = new ObservableCollection<Person>();
        People.Add(new Person { Name = "jimmy" });
    
                   // First Lamda is where we execute the command to add,
                   // The second lamda is the `Can` method to enable the button.
        AddPerson = new OperationCommand((o) => People.Add(new Person { Name = CurrentPerson }),
                                         (o) => (!string.IsNullOrWhiteSpace(CurrentPerson) && 
                                                 !People.Any(per => per.Name == CurrentPerson)));
        // When the edit box text changes force a `Can` check.
        this.PropertyChanged += MainViewModel_PropertyChanged ;
    }
    
    void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "CurrentPerson")
            AddPerson.RaiseCanExecuteChanged();
    }
