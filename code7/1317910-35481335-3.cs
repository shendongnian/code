        public class DynamicResourceConverter: IValueConverter, IMultiValueConverter
        {
            ....
            // original converter implementation for IValueConverter
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                ....
            }
            // newly added converter implementation for IMultiValueConverter
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                //call the original converter method with one value (assuming you've checked the array has at least one item!!
                return Convert(values[0], targetType, parameter, culture)
            }
            ....
        }
