       public class WordColorConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                string inputWord = (string)values[0];
                string correctWord = (string)values[1];
                if (inputWord.Equals(correctWord))
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
    
                throw new NotImplementedException();
            }
        }
