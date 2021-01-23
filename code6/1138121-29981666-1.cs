    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { FirstName = "Barack", LastName = "Obama" });
            persons.Add(new Person() { FirstName = "George", LastName = "Bush" });
            persons.Add(new Person() { FirstName = "Bill", LastName = "Clinton" });
            persons.Add(new Person() { FirstName = "Ronald", LastName = "Reagan" });
            this.myListView.ItemsSource = persons;
        }
    }
