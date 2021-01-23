    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    
    namespace App1
    {
        public class BoolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                bool boolValue = (bool)value;
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
    }
