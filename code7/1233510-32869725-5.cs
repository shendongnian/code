    public partial class MainWindow : Window
    {
        private MainViewModel mvm;
        public MainWindow()
        {
            var db = Database.GetChildren();
            mvm = new MainViewModel(db);
            InitializeComponent();
            DataContext = mvm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Do not do this, example only
            var f = new First("Billy");
            mvm.AddFirstChild(new FirstViewModel(f));
            //Prove that the event was raised in First, FirstViewModel see & handles it, and
            //the UI is updated
            f.AddChild(new Second(int.MaxValue));
        }
    }
