    public static class SortExtension
    {
        public static void SortBy<T, TProperty>(this List<T> list, Func<T, TProperty> orderby, bool ascending = true)
        {
            list.Sort(new InnerComparer<T, TProperty>(orderby, ascending));
        }
        class InnerComparer<T, TProperty> : IComparer<T>
        {
            private readonly Func<T, TProperty> _property;
            private readonly int _ascending;
            public InnerComparer(Func<T, TProperty> property, bool ascending)
            {
                _property = property;
                _ascending = ascending ? 1 : -1;
            }
            int IComparer<T>.Compare(T x, T y)
            {
                var p1 = _property(x);
                var p2 = _property(y);
                return _ascending * Comparer<TProperty>.Default.Compare(p1, p2);
            }
        }
    }
