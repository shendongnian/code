    public class ObjectSorter : ICustomSorter
    {
        public System.ComponentModel.ListSortDirection SortDirection { get; set; }
        public int Compare(object x, object y)
        {
            return x.ToString().CompareTo(y.ToString());
        }
    }
