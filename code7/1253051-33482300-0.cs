    public class LabelTemplate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //...
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //...
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LabelTemplate labelTemplateConverter = new LabelTemplate();
            Binding binding = new Binding("Item.Items");
            binding.Converter = labelTemplateConverter;
            txtBlock.SetBinding(TextBlock.TextProperty, binding);
        }
    }
