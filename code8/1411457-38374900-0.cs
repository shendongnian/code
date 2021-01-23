    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    namespace YourNamespace
    {
        public class BooleanToVisibilityConverter : IValueConverter
        {
            public Visibility OnTrue { get; set; }
            public Visibility OnFalse { get; set; }
            public BooleanToVisibilityConverter()
            {
                OnFalse = Visibility.Collapsed;
                OnTrue = Visibility.Visible;
            }
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                var v = (bool)value;
                return v ? OnTrue : OnFalse;
            }
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                if (value is Visibility == false)
                    return DependencyProperty.UnsetValue;
                if ((Visibility)value == OnTrue)
                    return true;
                else
                    return false;
            }
        }
    }
