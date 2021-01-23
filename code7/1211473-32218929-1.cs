    public static IEnumerable<DependencyObject> EnumerateVisualChildren(this DependencyObject dependencyObject)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
        {
            yield return VisualTreeHelper.GetChild(dependencyObject, i);
        }
    }
    public static IEnumerable<DependencyObject> EnumerateVisualDescendents(this DependencyObject dependencyObject)
    {
        yield return dependencyObject;
        foreach (DependencyObject child in dependencyObject.EnumerateVisualChildren())
        {
            foreach (DependencyObject descendent in child.EnumerateVisualDescendents())
            {
                yield return descendent;
            }
        }
    }
    public static void ClearBindings(this DependencyObject dependencyObject)
    {
        foreach (DependencyObject element in dependencyObject.EnumerateVisualDescendents())
        {
            BindingOperations.ClearAllBindings(element);
        }
    }
