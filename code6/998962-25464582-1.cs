            public class RowIndexConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var dict = value as Dictionary<string, object>;
                if (dict != null)
                {
                    Row row = new  Row(dict);
                    string index = parameter as string;
                    return row[index];
                }
                return null;
            }
     
     }
