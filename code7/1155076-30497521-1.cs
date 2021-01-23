    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(Days.OffDay.GetDescription());
        }
    }
