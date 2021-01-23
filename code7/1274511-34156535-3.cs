    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    namespace App1
    {
    public sealed partial class MainPage : Page
    { 
        public List<Activity> Activities { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            Activities = new List<Activity>();
            Activities.Add(new Activity { Name = "Activity1", Visible = true });
            Activities.Add(new Activity { Name = "Activity2", Visible = false });
        }
        private void delItem_Click(object sender, RoutedEventArgs e)
        {
            Activities.First().Visible = false;
        }
    }
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
    public class Activity : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool _visible; 
        public bool Visible {
            get { return _visible; }
            set
            {
                _visible = value;
                RaisePropertyChanged("Visible");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    }
