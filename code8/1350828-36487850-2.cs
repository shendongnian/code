    public partial class MainWindow : Window
    {
        public ObservableCollection<CustomControl> MyCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MyCollection = new ObservableCollection<CustomControl>();
            MyCollection.Add(new CustomControl { txt_Field1 = "Test 1", txt_Field2 = "Test 2", rad_RadBtn1 = "Rad1", rad_RadBtn2 = "Rad2", rad_RadBtn3 = "Rad3", rad_RadBtn4 = "Rad4" });
            MyCollection.Add(new CustomControl { txt_Field1 = "Test 3", txt_Field2 = "Test 4", rad_RadBtn1 = "Rad1", rad_RadBtn2 = "Rad2", rad_RadBtn3 = "Rad3", rad_RadBtn4 = "Rad4" });
            MyCollection.Add(new CustomControl { txt_Field1 = "Test 5", txt_Field2 = "Test 6", rad_RadBtn1 = "Rad1", rad_RadBtn2 = "Rad2", rad_RadBtn3 = "Rad3", rad_RadBtn4 = "Rad4" });
            DataContext = this;
        }
    }
