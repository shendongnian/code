    public class Person : BaseObservableObject
    {
        private string _lName;
        private string _fName;
        private bool _checked;
        private object _selectedServer;
        private DbDetails _selectedDb;
        public Person()
        {
            Dbs = new ObservableCollection<DbDetails>();
            Servers = new ObservableCollection<ServerDetails>(new List<ServerDetails>
            {
                new ServerDetails
                {
                    ServerName = "A",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails{DbName = "AA"},
                        new DbDetails{DbName = "AB"},
                        new DbDetails{DbName = "AC"},
                    }
                },
                 new ServerDetails
                {
                    ServerName = "B",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails{DbName = "BA"},
                        new DbDetails{DbName = "BB"},
                        new DbDetails{DbName = "BC"},
                    }
                },
                 new ServerDetails
                {
                    ServerName = "C",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails{DbName = "CA"},
                        new DbDetails{DbName = "CB"},
                    }
                }
            });
        }
        public DbDetails SelectedDb
        {
            get { return _selectedDb; }
            set
            {
                _selectedDb = value;
                OnPropertyChanged();
            }
        }
        public object SelectedServer
        {
            get { return _selectedServer; }
            set
            {
                _selectedServer = value;
                OnPropertyChanged();
                UpdateDbCollection(SelectedServer as ServerDetails);
            }
        }
        private void UpdateDbCollection(ServerDetails serverDetails)
        {
            var newDbs = serverDetails.DbDetailses;
            newDbs.ForEach(details => Dbs.Add(details));
            var valuesToClear =
                Dbs.Where(
                    existingDbDetails => newDbs.FirstOrDefault(dbDetails => existingDbDetails == dbDetails) == null).ToList();
            valuesToClear.ForEach(details => Dbs.Remove(details));
        }
        public ObservableCollection<ServerDetails> Servers { get; set; }
        public ObservableCollection<DbDetails> Dbs { get; set; }
        public bool IsChecked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertyChanged();
            }
        }
        public string LNAME
        {
            get { return _lName; }
            set
            {
                _lName = value;
                OnPropertyChanged();
            }
        }
        public string FNAME
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged();
            }
        }
    }
