    public partial class MainWindow : Window
    {
        private readonly List<Name> _nameList = new List<Name>
        {
            new Name("Eric","Clapton"),
            new Name("Mark", "Knopfler")
        };
        public MainWindow()
        {
            InitializeComponent();
            NamesDataGrid.ItemsSource = _nameList;
        }
    }
    
    internal class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
