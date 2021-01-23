    public class StableComparer : IComparer
    {
        public IEnumerable Collection { get; set; }
        public StableComparer(IEnumerable collection)
        {
            Collection = collection;
        }
        public int Compare(object x, object y)
        {
            IComparable x_Comparable = x as IComparable;
            IComparable y_Comparable = y as IComparable;
            if (x_Comparable != null && y_Comparable != null)
            {
                var comparison = x_Comparable.CompareTo(y_Comparable);
                // A zero value means x and y are equivalent for sorting, and they could
                //  be rearranged by an unstable sorting algorithm
                if (comparison == 0 && Collection != null)
                {
                    // IndexOf is an extension method for IEnumerable (not included)
                    var x_Index = Collection.IndexOf(x);
                    var y_Index = Collection.IndexOf(y);
                    // By comparing their indexes in the original collection, we get to
                    //  preserve their relative order
                    if (x_Index != -1 && y_Index != -1)
                        comparison = x_Index.CompareTo(y_Index);
                }
                return comparison;
            }
            return 0;
        }
    }
