     public class SumConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values != null && values.Length > 0 && values[0] is ObservableCollection<string>)
                {
                    ObservableCollection<DocView> items = (ObservableCollection<DocView>)values[0];
                    return string.Format("Count: {0}, Sum: {1}", items.Count, items.Sum(x => x.Price));
                }
                else
                    return "Count: 0, Sum: 0";
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
