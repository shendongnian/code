    public class StringToImageConverter : IValueConverter 
    { 
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
    { 
        var filename = (string)value; 
        return ImageSource.FromFile(filename); 
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }}
