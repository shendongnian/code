    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> persons { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            persons = new ObservableCollection<Person>();
            persons.Add(new Person() { Name = "Person1" });
            persons.Add(new Person() { Name = "Person2" });
            persons.Add(new Person() { Name = "Person3" });
            persons.Add(new Person() { Name = "Person4" });
            this.DataContext = this;
        }
    }
