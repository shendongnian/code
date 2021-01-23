    public class MyMultivalueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var AllButtonVisibility = values[values.Length-1] as AllButtonVisibility;
            foreach(object obj in values)
            {
                if (obj is Visibility)
                AllButtonVisibility.AllButtonVisible = ((Visibility)obj) == Visibility.Visible;
                if (AllButtonVisibility.AllButtonVisible)
                    return Binding.DoNothing;
            }            
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
