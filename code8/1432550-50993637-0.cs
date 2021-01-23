    public  class ItemSourceCountFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as IEnumerable;
            if (val == null)
                return value;
            int take = 10;
            if (parameter != null)
                int.TryParse(parameter as string, out take);
            
            if (take < 1)
                return value;
            var list = new List<object>();
            int count = 0;
            foreach (var li in val)
            {
                count++;
                if(count > take)
                    break;
                list.Add(li);
            }
            return list;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
