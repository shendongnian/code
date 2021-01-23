    public static Visual GetChildrenByType(Visual visualElement, Type typeElement, string nameElement)
    {
       if (visualElement == null) return null;
       if (visualElement.GetType() == typeElement)
         {
            FrameworkElement fe = visualElement as FrameworkElement;
            if (fe != null)
            {
              if (fe.Name == nameElement)
              {
                 return fe;
              }
            }
         }
         Visual foundElement = null;
         if (visualElement is FrameworkElement)
            (visualElement as FrameworkElement).ApplyTemplate();
         for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visualElement); i++)
         {
            Visual visual = VisualTreeHelper.GetChild(visualElement, i) as Visual;
            foundElement = GetChildrenByType(visual, typeElement, nameElement);
            if (foundElement != null)
               break;
         }
         return foundElement;
        }
