    public class SingleBackgroundValueConverter : MvxColorValueConverter<bool>
    {
        protected override MvxColor Convert(bool value, object parameter, CultureInfo culture)
        {
            return value ? new MvxColor(255, 255, 255) : new MvxColor(255, 0, 0);
        }
    }
