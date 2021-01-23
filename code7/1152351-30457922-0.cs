    public class CustomSorter : IComparer
    {
        public ListSortDirection? Direction { get; set; }
        public string SortMember { get; set; }
        public CustomSorter(string sortMember, ListSortDirection? direction)
        {
            SortMember = sortMember;
            Direction = direction;
        }
        // A custom comparer based on group header ("Category" in this example) 
        // in "B"<"A"<"C" order.
        public int Compare(object x, object y)
        {
            var xVm = (ItemViewModel)x;
            var yVm = (ItemViewModel)y;
            if (xVm.Category == yVm.Category)
                return CompareBySortMember(xVm,yVm);
            if (xVm.Category == "B")
                return -1;
            if (xVm.Category == "A" && yVm.Category == "C")
                return -1;
            return 1;
        }
        // When two items have the same Category, comparison is made based on 
        // "SortMemberPath" property of the sorting column.
        private int CompareBySortMember(ItemViewModel xVm, ItemViewModel yVm)
        {
            var xValue = xVm.GetType().GetProperty(SortMember).GetValue(xVm);
            var yValue = yVm.GetType().GetProperty(SortMember).GetValue(yVm);
            int result = xValue.ToString().CompareTo(yValue.ToString());
            return Direction == ListSortDirection.Ascending ? result * -1 : result;
        }
    }
