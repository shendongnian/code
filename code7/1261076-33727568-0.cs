    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                ProcessFolderLocation(dialog.SelectedPath);
            }
    
            private void ProcessFolderLocation(string location)
            {
                // ... Do something with your selected folder location
            }
        }
