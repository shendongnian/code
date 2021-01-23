        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {   
    // update validations as per your requirements...
                var dialog = new OpenFileDialog();
                dialog.Filter = "XML Files|*.xml";
                if (dialog.ShowDialog() == true)
                {   
                    lblXmlFileName.Content = dialog.FileName.ToString();
                    var provider1 = (XmlDataProvider) stackpanel1.Resources["provider1"];
                    if(provider1 != null)
                     provider1.Source = new Uri(dialog.FileName, UriKind.Absolute);
                }
            }
        }
