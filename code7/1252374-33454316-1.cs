    public class NullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        { return value; }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrEmpty((string)value)) return null;
            else return int.Parse((string)value);
        }
    }
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private int? _serves;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public int? Serves
        {
            get { return _serves; }
            set { _serves = value; RaiseProperty("Serves"); }
        }
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }
    }
