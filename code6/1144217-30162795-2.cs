        public class MainWindowViewModel : ViewModelBase
        {
            private Person _selectedPerson;
            private ObservableCollection<Person> _people;
    
            public event EventHandler Commit;
    
            public Person SelectedPerson
            {
                get { return _selectedPerson; }
                set { _selectedPerson = value; RaisePropertyChange("SelectedPerson"); }
            }
    
            public ObservableCollection<Person> People
            {
                get { return _people; }
                set { _people = value; RaisePropertyChange("People"); }
            }
    
            public ICommand CommitSelection
            {
                get
                {
                    return new RelayCommand<object>(o =>
                    {
                        if (Commit != null) Commit(this, new EventArgs());
                    });
                }
            }
        }
