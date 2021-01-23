     public class SomeData
    {
        public int Id { get; set; }
        public Days Days { get; set; }
    }
     public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;          
        }
        public ObservableCollection<SomeData> SomeCollection { get; set; }
    }
