    internal class WidthBehavior
    {
        private static Dictionary<string, List<FrameworkElement>> _scopes = new Dictionary<string, List<FrameworkElement>>();
        public static readonly DependencyProperty WidthShareScopeProperty = DependencyProperty.RegisterAttached(
            "WidthShareScope", typeof (string), typeof (WidthBehavior), new PropertyMetadata(default(string), PropertyChangedCallback));
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var elem = dependencyObject as FrameworkElement;
            if (elem == null) return;
            var scope = dependencyPropertyChangedEventArgs.NewValue as string;
            if (scope == null) return;
            if (!_scopes.ContainsKey(scope))
            {
                _scopes.Add(scope, new List<FrameworkElement>());
            }
            if (!_scopes[scope].Contains(elem))
            {
                _scopes[scope].Add(elem);
                elem.SizeChanged += elem_SizeChanged;
            }
        }
        static void elem_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var elem = sender as FrameworkElement;
            if (elem == null) return;
            var scope = GetWidthShareScope(elem);
            ArrangeScope(scope);
        }
        private static void ArrangeScope(string scope)
        {
            if (!_scopes.ContainsKey(scope)) return;
            
            var list = _scopes[scope];
            var maxWidth = list.Max(elem => elem.ActualWidth);
            list.ForEach(elem => elem.Width = maxWidth);
        }
        public static void SetWidthShareScope(DependencyObject element, string value)
        {
            element.SetValue(WidthShareScopeProperty, value);
        }
        public static string GetWidthShareScope(DependencyObject element)
        {
            return (string) element.GetValue(WidthShareScopeProperty);
        }
    }
