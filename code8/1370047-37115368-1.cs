    public abstract class ValueConverter
        : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public virtual object ConvertBack(object value, Type targetType,
                                          object parameter, CultureInfo culture)
        {
            return String.Empty;
        }
    }
    public class ButtonTextConverter : ValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            // Use the ButtonResources helper to find the text to place on the button.
            return ButtonResources.FindButton(value as String, culture).Text;
        }
    }
    public class ButtonImageConverter : ValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            // Use the ButtonResources helper to find the image to put on the button.
            return ButtonResources.FindButton(value as String, culture).Image;
        }
    }
    public class ButtonColourConverter : ValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            // Use the ButtonResources helper to find the brush to use for the button.
            return ButtonResources.FindButton(value as String, culture).Brush;
        }
    }
