     public static class VisualTreeHelperExt
        {
            public static T TryFindParent<T>(this DependencyObject child)
        where T : DependencyObject
            {
                DependencyObject parentObject = GetParentObject(child);
                if (parentObject == null) return null;
                T parent = parentObject as T;
                if (parent != null)
                {
                    return parent;
                }
                else
                {
                    return TryFindParent<T>(parentObject);
                }
            }
    
            public static DependencyObject GetParentObject(this DependencyObject child)
            {
                if (child == null) return null;
                ContentElement contentElement = child as ContentElement;
                if (contentElement != null)
                {
                    DependencyObject parent = ContentOperations.GetParent(contentElement);
                    if (parent != null) return parent;
                    FrameworkContentElement fce = contentElement as FrameworkContentElement;
                    return fce != null ? fce.Parent : null;
                }
                FrameworkElement frameworkElement = child as FrameworkElement;
                if (frameworkElement != null)
                {
                    DependencyObject parent = frameworkElement.Parent;
                    if (parent != null) return parent;
                }
                return VisualTreeHelper.GetParent(child);
            }
        }
