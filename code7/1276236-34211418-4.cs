    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    class ViewModel
    {
        public string ButtonType { get; set; }
    }
    class OrderedFlagConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImageArray imageData = (BitmapImageArray)parameter;
            string type = (string)values[0];
            foreach (ButtonImageStates buttonStates in imageData.Elements)
            {
                if (buttonStates.Key == type)
                {
                    int index = 1;
                    while (index < values.Length)
                    {
                        if ((bool)values[index])
                        {
                            break;
                        }
                        index++;
                    }
                    return buttonStates.StateImages[index - 1];
                }
            }
            return DependencyProperty.UnsetValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    [ContentProperty("Elements")]
    class BitmapImageArray
    {
        private readonly List<ButtonImageStates> _elements = new List<ButtonImageStates>();
        public List<ButtonImageStates> Elements
        {
            get { return _elements; }
        }
    }
    class ButtonImageStates
    {
        public string Key { get; set; }
        public BitmapImage[] StateImages { get; set; }
    }
