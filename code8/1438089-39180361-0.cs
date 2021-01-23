    public partial class MainWindow : Window
    {
        private static string appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private (static) string path = System.IO.Path.Combine(appdatapath, "second/part/of/folderpath"); //make this static if you want that this field can't be changed.
        public MainWindow()
        {
            InitializeComponent();
        }
    }
