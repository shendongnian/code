    public class StringToGlyphConverter : IValueConverter 
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
          if (value.GetType() != typeof(string))
          {
              return null;
          }
          string glyph = (value as string).Substring(3, 4); // for example: &#xe11b; will become e11b
          return (char)int.Parse(glyph, NumberStyles.HexNumber);
       }
       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
          return null;
       }
    }
