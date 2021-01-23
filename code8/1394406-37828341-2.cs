     public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
    
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();
                TimeZoneList = TimeZones;
                cmb_TZ.SelectedIndex = 1;
            }
    
            private void ComboBox_Selection(object sender, SelectionChangedEventArgs e)
            {
                var cmbBox = sender as ComboBox;
                DateTime currTime = DateTime.UtcNow;
                TimeZoneInfo tst = (TimeZoneInfo)cmbBox.SelectedItem;
                TimeZome = TimeZoneInfo.ConvertTime(currTime, TimeZoneInfo.Utc, tst).ToString("HH:mm:ss dd MMM yy");
            }
    
            private string _TimeZome;
            public string TimeZome
            {
                get { return _TimeZome; }
                set
                {
                    if (value == _TimeZome)
                        return;
    
                    _TimeZome = value;
                    this.OnPropertyChanged("TimeZome");
                }
            }
            private ReadOnlyCollection<TimeZoneInfo> _TimeZoneList;
            public ReadOnlyCollection<TimeZoneInfo> TimeZoneList
            {
                get { return _TimeZoneList; }
                set
                {
                    if (value == _TimeZoneList)
                        return;
    
                    _TimeZoneList = value;
                    this.OnPropertyChanged("TimeZoneList");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
