    public class ViewModel
    {
        // this is a property for filtering
        public bool Sex
        {
            get { ... }
            set
            {
                if (_sex != value) 
                {
                    _sex = value;
                    OnPropertyChanged();
                    PersonListView.Refresh();
                }
            }
        }
    
        // this is a property for filtering too
        public string Country
        {
            // call PersonListView.Refresh in setter, as in Sex property setter
        }  
    
        // this is a property for binding to DataGrid
        public ICollectionView PersonListView
        {
            get
            {
                if (_personListView == null)
                {
                    _personList = LoadPersons();
                    _personListView = new ListCollectionView(_personList)
                    {
                        Filter = p => ShouldViewPerson((Person)p);
                    }
                }
                return _personListView;
            }
        }
    
        private bool ShouldViewPerson(Person p)
        {
            // implement filtering logic here;
            // e.g.:
            return p.Country.StartsWith(Country) && p.Sex == Sex;
        }
    
        private ListCollectionView _personListView;
        private List<Person> _personList;
    }
