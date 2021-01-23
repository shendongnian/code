    public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double sum = 0;
            foreach (var item in value)
            {
                sum += System.Convert.ToDouble(item);
            }
            return sum;
        }
