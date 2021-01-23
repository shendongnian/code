    public class ListViewItemComparer : IEqualityComparer<ListViewItem>
    {
        bool IEqualityComparer<ListViewItem>.Equals(ListViewItem x, ListViewItem y)
        {
            return (x.Text == y.Text);
        }
    
        int IEqualityComparer<ListViewItem>.GetHashCode(ListViewItem obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;
    
            return obj.Text.GetHashCode();
        }
    }
