    public class comp_tree : IComparer
    {
        public int Compare(object xx, object yy)
        {
            string x = ((TreeNode)xx).Text;
            string y = ((TreeNode)yy).Text;
            return x.CompareTo(y);
        }
    }
