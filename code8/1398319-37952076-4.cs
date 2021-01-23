    public class EventLengthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan timelineDuration = (TimeSpan)values[0];
            TimeSpan relativeTime = (TimeSpan)values[1];
            double containerWidth = (double)values[2];
            double factor = relativeTime.TotalSeconds / timelineDuration.TotalSeconds;
            double rval = factor * containerWidth;
            if (targetType == typeof(Thickness))
            {
                return new Thickness(rval, 0, 0, 0);
            }
            else
            {
                return rval;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
