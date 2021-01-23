    public partial class MainWindow : Window
    {
        public List<User> items { get; private set; }
        public MainWindow()
        {
            items = new List<User>();
            items.Add(new User() { Name = "John Doe", Result = 42 });
            items.Add(new User() { Name = "Jane Doe", Result = 39 });
            items.Add(new User() { Name = "Sammy Doe", Result = 13 });
            InitializeComponent();
        }
    }
