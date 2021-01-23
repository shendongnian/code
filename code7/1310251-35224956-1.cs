    public class ClassItem
    {
        public List<ClassItem> Children { get; set; }
        public Int64 MaxChildren
        { 
            get
            {
                if (this.Children == null || this.Children.Count == 0)
                {
                    return 0;
                }
                int directChildrenCount = this.Children.Count();
                int descendantMaxCount = this.Children.Max(child => child.MaxChildren);
                return Math.Max(directChildrenCount, descendantMaxCount);
            }
        }
    }
