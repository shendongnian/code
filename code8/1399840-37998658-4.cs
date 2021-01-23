    namespace HollowEarth.Converters
    {
        public class BoolBrushConverter : MarkupExtension, IValueConverter
        {
            public Brush TrueBrush { get; set; }
            public Brush FalseBrush { get; set; }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return System.Convert.ToBoolean(value) ? TrueBrush : FalseBrush;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
    }
