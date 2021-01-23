    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApplication1
    {
        public class CountToFontWeightConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return DependencyProperty.UnsetValue;
                var count = (int)value;
    
                if (count > 10)
                    return FontWeights.Bold;
                else
                    return FontWeights.Normal;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
