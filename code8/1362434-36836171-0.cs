    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
    
    
        public sealed class ViewModel
        {
            public ObservableCollection<Issue> Issues { get; private set; }
    
            public ViewModel()
            {
                Issues = new ObservableCollection<Issue>();
            }
        }
    
        private void addIssue_Click(object sender, RoutedEventArgs e)
        {       
            vm.Issues.Add(new Issue { Name = "Jon Skeet", Comment = "lolilol" });       
        }
    }
