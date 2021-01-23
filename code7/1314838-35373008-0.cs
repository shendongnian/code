    public class x
    {
        public static ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public ObservableCollection<string> Items { get { return x.Items; } }
    }
