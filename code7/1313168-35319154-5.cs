    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Person> collection = new ObservableCollection<Person>();
        public ObservableCollection<Person> Collection
        {
            get { return collection; }
            set { collection = value; OnPropertyChanged(); }
        }
        private Person selectedPerson = new Person();
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; OnPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
            collection = new ObservableCollection<Person>() { { new Person("Murray", "Hart")}, { new Person("John", "Clifford") } };
            comboBox.ItemsSource = collection;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPerson = (Person)comboBox.SelectedItem;
        }
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedPerson.lastName);
        }
    }
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Person()
        {
        }
        public Person(string fname, string lname)
        {
            firstName = fname;
            lastName = lname;
        }
    }
