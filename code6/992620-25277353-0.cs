    public interface IItem
    {
        // interface members
    }
    public class Item<T> : IItem
    {
        // class members, and IItem implementation
    }
    public interface IItemCollection
    {
        IEnumerable<IItem> GetItems();
    }    
    public class ItemCollection<TKey, TItem> : IItemCollection, IEnumerable<TItem>
        where TItem : class,IItem,new()
    {
        private Dictionary<TKey, TItem> dictionary;
        public IEnumerator<TItem> GetEnumerator() { return dictionary.Values; }
        public IEnumerable<IItem> GetItems() { return dictionary.Values.Cast<IItem>(); }
    }
