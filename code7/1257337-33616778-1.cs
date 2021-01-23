    public class ColorToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) => new SolidColorBrush((Windows.UI.Color)value);
        public object ConvertBack(object value, Type targetType, object parameter, string language) { throw new NotImplementedException(); }
    }
    public sealed partial class MainPage : Page
    {
        // this is the shortcut of {get { return ... }}
        public Array MyColors => typeof(Windows.UI.Colors).GetRuntimeProperties()
                .Select(c => new
                {
                    Color = (Windows.UI.Color)c.GetValue(null),
                    Name = c.Name
                }).ToArray();  
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }
    }
