    public static class ViewModelLifeCycleBehavior
    {
        public static readonly DependencyProperty ActivateOnLoadProperty = DependencyProperty.RegisterAttached("ActivateOnLoad", typeof (bool), typeof (ViewModelLifeCycleBehavior),
            new PropertyMetadata(ActivateOnLoadPropertyChanged));
        public static void SetActivateOnLoad(FrameworkElement element, bool value)
        {
            element.SetValue(ActivateOnLoadProperty, value);
        }
        public static bool GetActivateOnLoad(FrameworkElement element)
        {
            return (bool)element.GetValue(ActivateOnLoadProperty);
        }
        private static void ActivateOnLoadPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        { 
            if (DesignerProperties.GetIsInDesignMode(obj)) return;
            var element = (FrameworkElement)obj;
            element.Loaded -= ElementLoaded;
            element.Unloaded -= ElementUnloaded;
            if ((bool) args.NewValue == true)
            {
                element.Loaded += ElementLoaded;
                element.Unloaded += ElementUnloaded;
            }
        }
        static void ElementLoaded(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement) sender;
            var viewModel = (IViewModelLifeCycle) element.DataContext;
            if (viewModel == null)
            {
                DependencyPropertyChangedEventHandler dataContextChanged = null;
                dataContextChanged = (o, _e) =>
                {
                    ElementLoaded(sender, e);
                    element.DataContextChanged -= dataContextChanged;
                };
                element.DataContextChanged += dataContextChanged;
            }
            else if (element.ActualHeight > 0 && element.ActualWidth > 0) //to avoid activating twice since loaded event is called twice on TabItems' subtrees
            {
                viewModel.Activate(null);
            } 
        }
        private static void ElementUnloaded(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            var viewModel = (IViewModelLifeCycle)element.DataContext;
            viewModel.Deactivate();
        }
    }
