    using System;
    using Windows.UI.Xaml.Data;
    
    namespace XBindTest4 {
    
        public class NoOpConverter : IValueConverter {
            public object Convert(object value, Type targetType, object parameter, string language)
                => value;
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
                => value;
    
        }
    }
