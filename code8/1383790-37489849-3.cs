    public abstract class ItemDataService<T>
        where T : ItemDataService<T>
    {
        public int Id { get; set; }
        // ...
    
        public void SaveItem(T item)
        {
            if (Item.Id <= 0) // Id is accessible now..
            {
                InsertItem(item);
            }
        }
    }
