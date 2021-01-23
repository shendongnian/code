    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel = new MainWindowViewModel();
		public MainWindow()
		{
            InitializeComponent();
            DataContext = viewModel;
        }
    }
    public class MainWindowViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private App currentApp = (Application.Current as App);
        public MainWindowViewModel()
        {
        }
        public string PhoneNumber
        {
            get
            {
                return currentApp.phoneglobal;
            }
            set
            {
                currentApp.phoneglobal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PhoneNumber"));
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
