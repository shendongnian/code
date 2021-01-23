    public class TitleTypeToSeparatorVisibilityConverter : IValueConverter
    {
        public object Convert(object value,	Type targetType, object parameter, CultureInfo culture)
        {
            var titleType = (TitleType) value;
            switch(titleType)
            {
                case TitleType.Title:
                    // return some value
                case TitleType.Subtitle:
                    // return some another one value
                default:
                    // handle this scenario
            }
        }
    }
