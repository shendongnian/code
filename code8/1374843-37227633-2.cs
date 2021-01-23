    public class SingleBackgroundValueConverter : MvxValueConverter<bool, ColorDrawable>
    {
        protected override ColorDrawable Convert(bool value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value ? new ColorDrawable(new Color(255, 255, 255)) : new ColorDrawable(new Color(255, 0, 0));
        }
    }
