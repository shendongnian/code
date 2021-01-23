    public class ItemManager : MonoBehavior
    {
        private Dictionary<int, MyItem> _itemDict;
    
        public void Awake()
        {
            var items = GetItems();
    
            //Makes a new dictionary from the array using the field Id as the key.
            _itemDict = items.ToDictionary(x => x.Id); 
        }
        public MyItem GetItem(int itemId)
        {
            return _itemDict[itemId];
        }
    
        private MyItem[] GetItems()
        {
            string json = GetJsonTextSomehow();
            ItemsContainer container = JsonUtility.FromJson<ItemsContainer>(json);
            return container.items;
        }
    
        private string GetJsonTextSomehow()
        {
           //...
        }
    }
