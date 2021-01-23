public class TextToBackgroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, 
        object parameter, CultureInfo culture)
    {
        // Validate the email text and retun background color of your choice 
    }
    public object ConvertBack(object value, Type targetType, 
        object parameter, CultureInfo culture)
    {
        // Not needed 
    }
}
