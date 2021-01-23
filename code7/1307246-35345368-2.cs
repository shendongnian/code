    public static class VisualTreeHelperExtensions
    {
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            while (true)
            {
                //get parent item
                DependencyObject parentObject = VisualTreeHelper.GetParent(child);
                //we've reached the end of the tree
                if (parentObject == null) return null;
                //check if the parent matches the type we're looking for
                T parent = parentObject as T;
                if (parent != null)
                    return parent;
                child = parentObject;
            }
        }
        public static List<DependencyObject> GetAllVisualChildren(this DependencyObject parent)
        {
            var resultedList = new List<DependencyObject>();
            var visualQueue = new Queue<DependencyObject>();
            visualQueue.Enqueue(parent);
            do
            {
                var depObj = visualQueue.Dequeue();
                var childrenCount = VisualTreeHelper.GetChildrenCount(depObj);
                for (int i = 0; i < childrenCount; i++)
                {
                    var v = VisualTreeHelper.GetChild(depObj, i);
                    visualQueue.Enqueue(v);
                }
                resultedList.Add(depObj);
            } while (visualQueue.Count > 0);
            resultedList.RemoveAt(0);
            return resultedList;
        }
    }
