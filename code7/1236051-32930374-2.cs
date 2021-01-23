    public class GridModel : ViewModelBase
    {
        public ObservableCollection<Record> customers { get; set; }
        public ObservableCollection<Country> countries
        {
            get;
            private set;
        }
        public GridModel()
        {
            customers = new ObservableCollection<Record> { };
            AddUserCommand = new RelayCommand(AddNewUser);
            countries = new ObservableCollection<Country> 
            { 
                new Country { id = 1, name = "England", code = 44 },
                new Country { id = 2, name = "Germany", code = 49 },
                new Country { id = 3, name = "US", code = 1},
                new Country { id = 4, name = "Canada", code = 11 }
            };
        }
        private void AddNewUser()
        {
            customers.Add(new Record());
        }
        public ICommand AddUserCommand { get; set; }
        private Record _selectedRow;
        public Record SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                Debug.Print("Datagrid selection changed");
                OnPropertyChanged("SelectedRow");
            }
        }
    }
