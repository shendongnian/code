    public class ItemCollection<T> : IEnumerable<T>
    {
        private List<T> Items;
    public IEnumerator<T> GetEnumerator()
    {
        return Items.GetEnumerator();
    }
    
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    }
