    public partial class MainWindow : Window
    {
        private ObservableCollection<CClass> cs = new ObservableCollection<CClass>();
        public MainWindow()
        {
            InitializeComponent();
            cs.Add(new CClass { A = new AClass { Prop2 = "WWW" } });
            listView.ItemsSource = cs;
        }
    }
