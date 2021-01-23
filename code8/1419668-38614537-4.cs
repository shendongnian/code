    public partial class ReadUserControl : UserControl
    {
        public ReadUserControl(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm.ReadViewModel;
        }
    }
