    namespace Windamow
    {
        /// <summary>
        /// Interaction logic for DynamoWindow.xaml
        /// </summary>
        public partial class DynamoWindow : Window, INotifyPropertyChanged
        {
            private String _reportPage;
            public String ReportPage { get { return _reportPage; } set { _reportPage = value; OnPropertyChanged("ReportPage"); } }
            
            public DynamoWindow()
            {
                InitializeComponent();
    
                browser.DataContext = this;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(String propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
