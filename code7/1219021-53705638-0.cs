        public class MarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTimeAxis = values[0] as DateTimeAxis; ;
            var actualAxisLength = values[1] as double?;
            var actualMaximum = values[2] as DateTime?;
            var actualMinimum = values[3] as DateTime?;
            if (dateTimeAxis == null || 
                !dateTimeAxis.Interval.HasValue || 
                !actualAxisLength.HasValue || 
                !actualMaximum.HasValue || 
                !actualMinimum.HasValue)
                return null;
            double xMargin = 0;
            var interval = dateTimeAxis.Interval.Value;
            var timeSpan = actualMaximum.Value - actualMinimum.Value;
            var timeSpanInDays = timeSpan.TotalDays;
            if (dateTimeAxis.IntervalType == DateTimeIntervalType.Months)
            {
                xMargin = 30 * interval * actualAxisLength.Value / timeSpanInDays;
            }
            else if (dateTimeAxis.IntervalType == DateTimeIntervalType.Days)
            {
                xMargin = interval * actualAxisLength.Value / timeSpanInDays;
            }
            return new Thickness(xMargin, 10, 0, -30);
        }
        public object[] ConvertBack(object value, System.Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
