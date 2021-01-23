    public class QItemsList<TItem> where TItem : QAbstractItem
    {
        public List<TItem> xItems = new List<TItem>();
        protected void add(TItem xItem)
        {
            xItems.Add(xItem);
        }
        public void getFirst(out TItem yItem)
        {
            yItem = xItems[0];        // XXX
        }
    }
