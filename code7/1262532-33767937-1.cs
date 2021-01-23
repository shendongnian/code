    public class RoseTree<T>
    {
        public T Value;
        public IEnumerable<Lazy<RoseTree<T>>> Children;
        public IEnumerable<T> Flatten()
        {
            return Enumerable.Repeat(this, 1)
                .Expand(item => item.Children != null ? item.Children.Select(c => c.Value) : null)
                .Select(item => item.Value);
        }
    }
