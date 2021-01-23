    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }       
    }
    class MainViewModel
    {
        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private string otherProp;
        public string OtherProp
        {
            get { return otherProp; }
            set { otherProp = value; }
        }
        public MainViewModel()
        {
            Role = "Admin";
            OtherProp = "Fail";
        }
    }
    class VisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0].ToString().Equals("Admin") && values[1].ToString().Equals("Pass"))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
