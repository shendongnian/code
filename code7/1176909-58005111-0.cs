    internal class StretchingExpanderHeaderBehavior : Behavior<Expander>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += StretchHeader;
        }
        private void StretchHeader(object sender, RoutedEventArgs e)
        {
            DependencyObject header = AssociatedObject.Header as DependencyObject;
            if (header != null)
            {
                ContentPresenter contentPresenter = VisualTreeHelper.GetParent(header) as ContentPresenter;
                if (contentPresenter != null)
                {
                    contentPresenter.HorizontalAlignment = HorizontalAlignment.Stretch;
                }
            }
        }
    }
