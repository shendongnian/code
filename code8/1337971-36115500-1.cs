    public class ClassXCompare : IEqualityComparer<Parent>
    {
        public bool Equals(Parent x, Parent y)
        {
            var child = (Child)y;
            return x.X == child.Y;
        }
    
        public int GetHashCode(Parent parent)
        {
            var child = parent as Child;
            return child == null ?
                parent.X : child.Y.
        }
    }
