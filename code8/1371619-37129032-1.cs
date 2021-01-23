    public partial class MainWindow : Window
    {
        public List<Bird> Birds { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            Birds = new List<Bird>();
    
            var bird1 = new Bird();
            bird1.CommonName = "Mallard";
            Birds.Add(bird1);
    
            var bird2 = new Bird();
            bird2.CommonName = "Red-winged Blackbird";
            Birds.Add(bird2);
    
            this.DataContext = this;
        }
    
        public class Bird
        {
            public string CommonName { get; set; }
        }
    }
