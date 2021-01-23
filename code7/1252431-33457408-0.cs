        public static IEnumerable<DependencyObject> Descendants(this DependencyObject element)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
 
            for (int i = 0; i < childrenCount; i++)
            {
                var visualChild = VisualTreeHelper.GetChild(element, i);
 
                yield return visualChild;
 
                foreach (var visualChildren in Descendants(visualChild))
                {
                    yield return visualChildren;
                }
            }
        }
