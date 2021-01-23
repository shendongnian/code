    public static class VTHelper
    {
        public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;
            T childElement = null; 
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent); 
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T; 
                if (childType == null)
                {
                    childElement = FindChild<T>(child); 
                    if (childElement != null) 
                        break;
                }
                else
                {
                    childElement = (T)child; 
                    break;
                }
            } 
            return childElement;
        }
    }
