    public class GetVisualDescendantProperty : MarkupExtension, IValueConverter
    {
        public DependencyProperty Property { get; set; }
        public Type Type { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as DependencyObject)
                ?.GetDescendants()
                .Where(d => d.GetType() == Type)
                .FirstOrDefault()
                ?.GetValue(Property);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    public static class Extensions
    {
        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); ++i)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                yield return child;
                foreach (var descendant in child.GetDescendants())
                {
                    yield return descendant;
                }
            }
        }
    }
