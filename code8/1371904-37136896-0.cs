    public class ListViewItemComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (((ListViewItem)x).Index > ((ListViewItem)y).Index ? 1 : -1);
        }
    }
