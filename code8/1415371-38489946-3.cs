     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
    public class ViewModel:INotifyPropertyChanged
    {
        private MyColor backColor;
        public MyColor BackgroundColour
        {
            get { return backColor; }
            set { backColor = value; OnPropertyChanged("BackgroundColour"); }
        }
        public ICommand SubmitCommand { get; set; }
        public ViewModel()
        {
            BackgroundColour = MyColor.Red;
            SubmitCommand = new BaseCommand(Execute);
        }
        public void Execute(object parameter)
        {
            BackgroundColour = MyColor.Yellow;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    public enum MyColor
    {
        Red,
        Green,
        Yellow
    }
    public class BaseCommand : ICommand
    {
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;
        public BaseCommand(Action<object> method)
        {
            _method = method;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
    public class ColorConverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            MyColor color = (MyColor)value;
            switch (color)
            {
                case MyColor.Red:
                    return Brushes.Red;
                case MyColor.Green:
                    return Brushes.Green;
                case MyColor.Yellow:
                    return Brushes.Yellow;
                default:
                {
                    return Brushes.Red;
                }
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
