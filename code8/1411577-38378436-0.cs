    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace OCLMEditor.ValueConverters
    {
        [ValueConversion(typeof(int), typeof(bool))]
        public class IsCurrentZoomFactor : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int currentZoomFactor = (int)value;
                string strDesiredZoomFactor = (string)parameter;
                int desiredZoomFactor = int.Parse(strDesiredZoomFactor);
                return desiredZoomFactor == currentZoomFactor;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return int.Parse((string)parameter);
                //throw new NotImplementedException();
            }
        }
    }
