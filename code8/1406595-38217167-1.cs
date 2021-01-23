    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace WpfApplication1.ViewModel
    {
        public class TestConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    var si = value.ToString();
                    if (si.Equals("B"))
                        return true;
                }
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
