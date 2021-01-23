    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
            People.Add( new Person {Name = "jimmy"});
            AddPersonDelegateCommand = new DelegateCommand(AddPerson, CanAddPerson);
        }
      // Your existing code here
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
          if(propertyName == "NewNameTextBox") AddPersonDelegateCommand.RaiseCanExecuteChanged();
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }
      public DelegateCommand AddPersonDelegateCommand { get; set; }
      public void AddPerson()
      { 
          // Code to add a person to the collection
      }
      public bool CanAddPerson()
      {
          return !People.Any(p=>p.Name == NewNameTextBox);
      }
      public string NewNameTextBox 
      { 
        get { return _newNameTextBox; }
        set 
        { 
           _newNameTextBox = value;
           OnPropertyChanged();
        }
      }
    }
