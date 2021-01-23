    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        SolidColorBrush b = new SolidColorBrush(Colors.Black);            
        var item = (Item)value;
        if (item.IsChanged) {
            b = Brushes.Red;
        }        
        return b;
    }
