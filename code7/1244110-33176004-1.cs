    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var f = new Functions();
            ContentRendered += f.LoadFolderTree;
        }
    }
    public class Functions
    {
        public  void LoadFolderTree(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Hello");
        }
    }
