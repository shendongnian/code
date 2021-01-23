    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty PersonsProperty = DependencyProperty.Register("Persons",
            typeof (ObservableCollection<Person>), typeof (MainWindow),
            new PropertyMetadata(default(ObservableCollection<Person>)));
        public static readonly DependencyProperty MainSourceProvidingFactoryProperty =
            DependencyProperty.Register("MainSourceProvidingFactory", typeof (SourceProvidingFactory),
                typeof (MainWindow), new PropertyMetadata(default(SourceProvidingFactory)));
        public ObservableCollection<Person> Persons
        {
            get { return (ObservableCollection<Person>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public SourceProvidingFactory MainSourceProvidingFactory
        {
            get { return (SourceProvidingFactory)GetValue(MainSourceProvidingFactoryProperty); }
            set { SetValue(MainSourceProvidingFactoryProperty, value); }
        }
        public MainWindow()
        {
            MainSourceProvidingFactory = new SourceProvidingFactory(GetCollection);
            InitSources();
            InitializeComponent();
        }
        private ObservableCollection<DbDetails> GetCollection(object arg)
        {
            var sereverDetails = arg as ServerDetails;
            return sereverDetails == null ? null : new ObservableCollection<DbDetails>(sereverDetails.DbDetailses);
        }
        private void InitSources()
        {
            var l = new List<Person>
            {
                new Person {FNAME = "John", LNAME = "W"},
                new Person {FNAME = "George", LNAME = "R"},
                new Person {FNAME = "Jimmy", LNAME = "B"},
                new Person {FNAME = "Marry", LNAME = "B"},
                new Person {FNAME = "Ayalot", LNAME = "A"},
            };
            Persons = new ObservableCollection<Person>(l);
            ServersCollection = new ObservableCollection<ServerDetails>(new List<ServerDetails>
            {
                new ServerDetails
                {
                    ServerName = "A",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails {DbName = "AA"},
                        new DbDetails {DbName = "AB"},
                        new DbDetails {DbName = "AC"},
                    }
                },
                new ServerDetails
                {
                    ServerName = "B",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails {DbName = "BA"},
                        new DbDetails {DbName = "BB"},
                        new DbDetails {DbName = "BC"},
                    }
                },
                new ServerDetails
                {
                    ServerName = "C",
                    DbDetailses = new List<DbDetails>
                    {
                        new DbDetails {DbName = "CA"},
                        new DbDetails {DbName = "CB"},
                    }
                }
            });
        }
        public ObservableCollection<ServerDetails> ServersCollection { get; set; }
    }
    public class SourceProvidingFactory
    {
        public SourceProvidingFactory(Func<object, ObservableCollection<DbDetails>> action)
        {
            GetCollection = action;
        }
        public Func<object, ObservableCollection<DbDetails>> GetCollection { get; set; }
    }
    public class Person : BaseObservableObject
    {
        private string _lName;
        private string _fName;
        private bool _checked;
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
    public class ServerDetails : BaseObservableObject
    {
        private string _serverName;
        public string ServerName
        {
            get { return _serverName; }
            set
            {
                _serverName = value;
                OnPropertyChanged();
            }
        }
        public List<DbDetails> DbDetailses { get; set; }
    }
    public class DbDetails : BaseObservableObject
    {
        private string _dbName;
        public string DbName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                OnPropertyChanged();
            }
        }
    }
