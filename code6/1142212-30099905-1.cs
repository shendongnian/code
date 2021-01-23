    public partial class MainWindow : Window
    {
        PatientMgr koko   = new PatientMgr();
        public MainWindow()
        {
            InitializeComponent();
            koko.Entity.Id = 0;
            koko.EntityList = koko.RetrieveMany(koko.Entity);
            DataContext = koko;
        }
    }
