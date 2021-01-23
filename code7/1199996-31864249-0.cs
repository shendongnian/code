    public class BaseClass<TItem>
    {
        public BaseClass()
        {
            ItemList = new List<TItem>();
        }
        public List<TItem> ItemList { get; set; }
    }
    public static void AddItem<T, TItem>(this T entity, TItem item)
        where T :BaseClass<TItem>
    {
        //somecode 
        entity.ItemList.Add(item);
    }
    public class TItem
    {
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        BaseClass<TItem> myEntity = new BaseClass<TItem>();
        TItem newItem = new TItem();
        newItem.Name = "Hi";
        myEntity.AddItem(newItem);
    }
