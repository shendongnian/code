    public class ArrayCoordinateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ViewModelClassHere viewModel = (value as ViewModelClassHere);
    
            if (viewModel != null)
            {
                // Assuming that X1 will always have cooresponding elements in X2, Y1, Y2;
                var enumerable = viewModel .X1.Select((x, i) => new
                {
                    X1 = x, 
                    X2 = viewModel.X2[i], 
                    Y1 = viewModel.Y1[i], 
                    Y2 = viewModel.Y2[i]
                });
    
                return  enumerable;
            }
    
            return null;
        }
    
        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
