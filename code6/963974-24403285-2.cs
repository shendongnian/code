    public class PhonePageToLLSConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
            CultureInfo culture)
        {
            var pageHeight = (double)value;
            return layoutHeight - (TotalMargins + PivotHeaderHeight);
        }
    }
