     class BackgroundConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var background = value as SolidColorBrush;
                if (background.Color == Colors.LightYellow) return new SolidColorBrush(Colors.Yellow);
                if (background.Color == Colors.LightGreen) return new SolidColorBrush(Colors.Green);
                return new SolidColorBrush(Colors.White);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
     
