    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> persons { get; set; }
        public Person SelectedPerson
        {
            get { return (Person)GetValue(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPersonProperty =
            DependencyProperty.Register("SelectedPerson", typeof(Person), typeof(MainWindow), new PropertyMetadata(null));
        public MainWindow()
        {
            InitializeComponent();
            persons = new ObservableCollection<Person>();
            persons.Add(new Person() { Name = "Name1", Age = 20 });
            persons.Add(new Person() { Name = "Name2", Age = 25 });
            persons.Add(new Person() { Name = "Name3", Age = 30 });
            this.DataContext = this;
        }
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            persons.Add(new Person() { Name = "NameAdded", Age = 50 });
        }
    }
