    public partial class MainWindow : Window
    {
        StructureVm _struct = new StructureVm("Test");
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _struct;
        }
    }
