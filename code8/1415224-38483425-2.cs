    public class GetScrollViewerProperty : MarkupExtension, IValueConverter
    {
        public DependencyProperty Property { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dobj = value as DependencyObject;
            var scrollViewer = dobj.GetDescendants().OfType<ScrollViewer>().FirstOrDefault();
            if (scrollViewer != null)
            {
                return scrollViewer.GetValue(Property);
            }
            return null;
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
        //  Based on this, which is broken: 
        //  http://stackoverflow.com/a/20048605/424129
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
