    public abstract class ItemDataService<T> where T : SomeInterface
    {
        // ...
    
        public void SaveItem(T item)
        {
            if (Item.Id <= 0) // Id is accessible now..
            {
                InsertItem(item);
            }
        }
    }
