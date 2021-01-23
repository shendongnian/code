    public partial class MainWindow : Window
    {
        private WhisperReader wr;
        public MainWindow()
        {
            InitializeComponent();
            wr = new WhisperReader();
            whisperDataGrid.DataContext = wr;
        }
    public class WhisperReader : INotifyPropertyChanged
    {
        ObservableCollection<WhisperModel> _whispers;
        public ObservableCollection<WhisperModel> whispers 
        { 
          get { return _whispers; } 
          private set 
          {
             _whispers = value;
             NotifyPropertyChanged(); 
          }
        }
    
        public WhisperReader()
        {
            whispers = new ObservableCollection<WhisperModel>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    public class WhisperModel : INotifyPropertyChanged
    {
        public DateTime sentTime { get; set; }
        private string _sender;
        public string sender 
        { 
            get { return _sender; } 
            set { _sender = value; NotifyPropertyChanged();
        }
        private string _message;
        public string message 
        { 
            get { return _message; } 
            set { _message = value; NotifyPropertyChanged();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    <DataGrid x:Name="whisperDataGrid" Margin="10,69,10,10" IsReadOnly="True" AutoGenerateColumns="True" ItemsSource="{Binding whispers}"/>
