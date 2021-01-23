     // Summary:
        //     Provides a way to apply custom logic to a binding.
        public interface IValueConverter
        {
            // Summary:
            //     Converts a value.
            //
            // Parameters:
            //   value:
            //     The value produced by the binding source.
            //
            //   targetType:
            //     The type of the binding target property.
            //
            //   parameter:
            //     The converter parameter to use.
            //
            //   culture:
            //     The culture to use in the converter.
            //
            // Returns:
            //     A converted value. If the method returns null, the valid null value is used.
            object Convert(object value, Type targetType, object parameter, CultureInfo culture);
            //
            // Summary:
            //     Converts a value.
            //
            // Parameters:
            //   value:
            //     The value that is produced by the binding target.
            //
            //   targetType:
            //     The type to convert to.
            //
            //   parameter:
            //     The converter parameter to use.
            //
            //   culture:
            //     The culture to use in the converter.
            //
            // Returns:
            //     A converted value. If the method returns null, the valid null value is used.
            object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
