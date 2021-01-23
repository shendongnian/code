    var elementList = new List<DependencyObject>();
    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
    {
        var element = VisualTreeHelper.GetChild(dependencyObject, i);
        if ((Visibility)element.GetValue(FrameworkElement.VisibilityProperty) == Visibility.Visible)
            elementList.Add(element);
    }
