     class GridViewLengthConverter:IValueConverter{
        
        
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double val = (int)value;
                GridLength gridLength = new GridLength(val);
    
                return gridLength;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                GridLength val = (GridLength)value;
    
                return val.Value;
            }
        }
