    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return this._selectedPerson;
            }
            set
            {
                this._selectedPerson = value;
                NotifyPropertyChanged("SelectedPerson");
            }
        }
        ObservableCollection<Person> _people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get
            {
                return this._people;
            }
        }
        public MainWindow()
        {
            var guy = new Person("Me");
            this.People.Add(guy);      // <---- ADDED GUY ONCE
            this.People.Add(new Person("You"));
            this.People.Add(new Person("Us"));
            this.People.Add(guy);     // <----- SAME GUY ADDED
            this.SelectedPerson = this.People[0];
            InitializeComponent();
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
