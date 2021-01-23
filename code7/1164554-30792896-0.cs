    ==in xaml==
    <Rectangle Width="100" Height="100" Fill="{Binding Color, Converter={StaticResource MyConverter}}"/>
    ==in view model==
    private Color color;
    public Color Color
    {
        get { return color; }
        set 
        { 
            color = value;
            RaisePropertyChnaged("Color");
        }
    }
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = (Color)value;
            return new SolidColorBrush(c);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    ==in xaml.cs==
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(() => {
            mViewModel.Color = (Colors.Green);
        });
    }
