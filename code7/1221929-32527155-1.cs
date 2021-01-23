    namespace SpecialFactory
    {
        public class Manager
        {
            static Manager()
            {
                ItemBase.RegisterAllCreators();
            }
            protected static Dictionary<ItemType, Func<ItemBase>> creators = new Dictionary<ItemType, Func<ItemBase>>();
            protected readonly List<ItemBase> managedItems = new List<ItemBase>();
            protected ItemBase CreateItem(ItemType type)
            {
                ItemBase item = null;
                if (creators.ContainsKey(type))
                {
                    if ((item = creators[type]()) != null)
                        managedItems.Add(item);
                }
                
                return item;    
            }
            public static void RegisterCreator(ItemType type, Func<ItemBase> creator)
            {
                if (!creators.ContainsKey(type))
                    creators[type] = creator;
            }
            public Manager()
            {
                
            }
            public ItemBase Test(ItemType type)
            {
                // var notAllowed = new Item1();
                var allowed = CreateItem(type);
                return allowed;
            }
        }
    }
