    public partial class MainWindow : Window
    {
        ViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            this.DataContext = vm;
        }
        
        
    }
    public class ViewModel
    {
        public ObservableCollection<string> Options { get; set; }
        public ObservableCollection<question> Questions { get; set; }
        public ViewModel()
        {
            Options = new ObservableCollection<string> { "Yes", "No", "Maybe" };
            Questions = new ObservableCollection<question>();
            Questions.Add(new question());
            Questions.Add(new question());
            Questions.Add(new question());
        }
        
    }
    public class question
    {
        public string selectedOption { get; set; }
    }
