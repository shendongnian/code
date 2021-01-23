    element.RegisterPropertyChangedCallback(UIElement.VisibilityProperty, VisibilityChanged);
    ...
    private void VisibilityChanged(DependencyObject sender, DependencyProperty property)
    {
        var visibility = ((UIElement)sender).Visibility;
        ...
    }
