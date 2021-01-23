    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var provider = (XmlDataProvider)null;
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML Files|*.xml";
            if (dialog.ShowDialog() == true)
            {
                provider = new XmlDataProvider();
                lblXmlFileName.Content = dialog.FileName.ToString();
                provider.Source = new Uri(dialog.FileName, UriKind.Absolute);
            }
        }
    }
