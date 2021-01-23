    private DependencyObject FindControlInDataTemplate<T>(DependencyObject control, string controlName)
    {
       int controlNumber = VisualTreeHelper.GetChildrenCount(control);
       for (int i = 0; i < controlNumber; i++)
       {
          DependencyObject yourControl = VisualTreeHelper.GetChild(control, i);
          FrameworkElement frameworkElement = yourControl as FrameworkElement;
          // Not a framework element or is null
          if (frameworkElement == null) return null;
          if (yourControl is T && frameworkElement.Name == controlName)
          {
             // Return your DataGrid
             return yourControl;
          }
          else
          {
              // If we've not found dataGrid, then we should see deeper
              DependencyObject nextLevel = FindControlInDataTemplate<T>(yourControl, controlName);
              if (nextLevel != null)
                 return nextLevel;
          }
       }
       return null;
    }
