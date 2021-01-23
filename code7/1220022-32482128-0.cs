    private DependencyObject FindControl<T>(DependencyObject control, string ctrlName)
    {
       int childNumber = VisualTreeHelper.GetChildrenCount(control);
       for (int i = 0; i < childNumber; i++)
       {
          DependencyObject child = VisualTreeHelper.GetChild(control, i);
          FrameworkElement fe = child as FrameworkElement;
          if (fe == null) return null;
          if (child is T && fe.Name == ctrlName)
          {
             return child;
           }
           else
           {
              DependencyObject nextLevel = FindControl<T>(child, ctrlName);
              if (nextLevel != null)
                 return nextLevel;
           }
        }
        return null;
     }
