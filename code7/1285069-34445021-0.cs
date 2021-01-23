    BackgroundColor="{Binding Path=IsRound, Converter={StaticResource BoolToFillColorConverter}}"
    public class BoolToFillColorConverter: IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          bool b;
          if (bool.TryParse(value, out b))
          {
            if (b) return Red
            else return Blue;
          }
          else
          {
            return SomeDefaultColour;
          }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return null;
      }
    }
