    public class RoutedCommandToInputGestureTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            RoutedCommand command = value as RoutedCommand;
            if (command != null)
            {
                InputGestureCollection col = command.InputGestures;
                if ((col != null) && (col.Count >= 1))
                {
                    // Search for the first key gesture
                    for (int i = 0; i < col.Count; i++)
                    {
                        KeyGesture keyGesture = ((IList)col)[i] as KeyGesture;
                        if (keyGesture != null)
                        {
                            return keyGesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture);
                        }
                    }
                }
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
