    public class FilteredVMComparer : IEqualityComparer<FilteredVM>
    {
        public static readonly FilteredVMComparer Instance = new FilteredVMComparer();
        private FilteredVMComparer()
        {
        }
        public bool Equals(FilteredVM x, FilteredVM y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(FilteredVM obj)
        {
            return obj.ID;
        }
    }
