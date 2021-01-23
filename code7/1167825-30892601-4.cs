    public static class VisualTreeUtility
    {
        public static T FindDescendant<T>(DependencyObject ancestor) where T : DependencyObject
        {
            return FindDescendant<T>(ancestor, item => true);
        }
        public static T FindDescendant<T>(DependencyObject ancestor, Predicate<T> predicate) where T : DependencyObject
        {
            return FindDescendant(typeof(T), ancestor, item => predicate((T)item)) as T;
        }
        public static DependencyObject FindDescendant(Type itemType, DependencyObject ancestor, Predicate<DependencyObject> predicate)
        {
            if (itemType == null) throw new ArgumentNullException("itemType");
            if (ancestor == null) throw new ArgumentNullException("ancestor");
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (!typeof(DependencyObject).IsAssignableFrom(itemType)) throw new ArgumentException("itemType", "The passed in type must be or extend DependencyObject");
            Queue<DependencyObject> queue = new Queue<DependencyObject>();
            queue.Enqueue(ancestor);
            while (queue.Count > 0)
            {
                DependencyObject currentChild = queue.Dequeue();
                if (currentChild != ancestor && itemType.IsAssignableFrom(currentChild.GetType()))
                {
                    if(predicate.Invoke(currentChild))
                    {
                        return currentChild;
                    }
                }
                int count = VisualTreeHelper.GetChildrenCount(currentChild);
                for (int i = 0; i < count; ++i)
                {
                    queue.Enqueue(VisualTreeHelper.GetChild(currentChild, i));
                }
            }
            return null;
        }
    }
