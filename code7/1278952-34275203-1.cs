    public partial class MainWindow : Window
    {
        public ObservableCollection<File> Files {get; set;}
    
    
        public MainWindow()
        {
    
            InitializeComponent();
            DataContext = this;
            Files = new ObservableCollection<File>();
            Files.Add(new File("r", DateTime.Now));
            Files.Add(new File("o", DateTime.Now));
            Files.Add(new File("a", DateTime.Now));
            Files.Add(new File("d", DateTime.Now));
            Files.Add(new File("d", DateTime.Now));
            Files.Add(new File("d", DateTime.Now));
        }
    }
