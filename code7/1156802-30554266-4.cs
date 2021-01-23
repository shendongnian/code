    public class ListViewExtension
    {
        public static readonly DependencyProperty FilterSourceProperty =
      DependencyProperty.RegisterAttached("FilterSource", typeof(string), typeof(ListViewExtension),
            new FrameworkPropertyMetadata(null, OnTextBoxSet));
        public static string GetFilterSource(DependencyObject dObj)
        {
            return (string)dObj.GetValue(FilterSourceProperty);
        }
        public static void SetFilterSource(DependencyObject dObj, string value)
        {
            dObj.SetValue(FilterSourceProperty, value);
        }
        private static void OnTextBoxSet(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
        {
            var listView = dObj as ListView;
            var text = e.NewValue as string;
            if ((listView == null) || (text == null)) return;
            var view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            if (view == null) return;
            view.Filter += item =>
            {
                var itemPl = (Employee) item;
                return itemPl.UserName.Contains(text);
            };
        }
    }
