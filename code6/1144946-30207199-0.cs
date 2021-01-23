    public class UnderlineTextValueConverter : MvxValueConverter<string, NSAttributedString>
        {
            protected override NSAttributedString Convert(string value, Type targetType, object parameter, CultureInfo cultureInfo)
            {
                var attrs = new UIStringAttributes {
                    UnderlineStyle = NSUnderlineStyle.Single
                };
                return new NSAttributedString(value, attrs);
            }
        }
