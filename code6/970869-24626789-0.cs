    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        private void RaiseProperty(string name) { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name)); }
        public static int globalValue = 0; // your global value
        public string TextBoxValue
        {
            get { return globalValue.ToString(); }
            set
            {
                if (!int.TryParse(value, out globalValue)) globalValue = 0; // some check-up if number is not valid
                RaiseProperty("TextBoxValue"); // update textbox
            }
        }
        public MainPage()
        {
            InitializeComponent();
            DataContext = this; // here or in XAML
        }
    }
