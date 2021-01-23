    namespace MyConverters
    {
      public class BoolToBrush : IValueConverter
      {
        private Brush FalseValue = new SolidColorBrush(Colors.Gray);
        public Brush TrueValue = Application.Current.Resources["PhoneAccentBrush"] as Brush;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return FalseValue;
            else return (bool)value ? TrueValue : FalseValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value != null ? value.Equals(TrueValue) : false;
        }
      }
    }
