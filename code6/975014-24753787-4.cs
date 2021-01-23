    namespace CSharpWPF
    {
        class CollectionSplitter:IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                List<IEnumerable<object>> result = new List<IEnumerable<object>>();
                IEnumerable<object> collection = (value as IEnumerable).OfType<object>();
                for (int i = 0; i < collection.Count(); i+=3)
                {
                    result.Add(collection.Skip(i).Take(3));
                }
                return result;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
