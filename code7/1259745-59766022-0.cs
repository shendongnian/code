    public class BackgroundColorConverter : MvxValueConverter<bool, Color>
    {
        protected override Color Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? Color.Black : Color.White;
        }
    }
