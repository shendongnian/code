    public class ClassItem
    {
        public List<ClassItem> Children { get; set; }
        public Int64 MaxChildren
        { 
            get
            {
                if (item.Children == null || item.Children.Count == 0)
                {
                    return 0;
                }
                int directChildrenCount = item.Children.Count();
                int descendantMaxCount = item.Children.Max(child => child.MaxChildren);
                return Math.Max(directChildrenCount, descendantMaxCount);
            }
        }
    }
