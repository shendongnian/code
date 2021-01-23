    public class MyBoolCollection: Collection<bool>
    {
        // called on Add/Insert
        protected override void InsertItem(int index, bool item)
        {
            // do some checks here
            base.InsertItem(index, item);
        }
        // called on Remove/RemoveAt
        protected override void RemoveItem(int index)
        {
            // do some checks here
            base.RemoveItem(index, item);
        }
 
        // called when an element is set by the indexer
        protected override void SetItem(int index, bool item)
        {
            // do some checks here
            base.SetItem(index, item);
        }
    }
