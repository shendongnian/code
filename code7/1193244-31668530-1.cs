    public class ItemManagerAdapter<TItemManagerAdapter, TItem>
        where TItemManagerAdapter : ItemManagerAdapter<TItemManagerAdapter, TItem>, new() 
        where TItem : BaseItem
    {
        private TItemManagerAdapter instance = new TItemManagerAdapter();
        protected abstract void SaveItem(TItem item);
        protected abstract TItem GetItem(long id, long callerId);
        protected abstract List<TItem> GetItemsByCallerId(long callerId);
        protected abstract void DeactivateItem(long id, long callerId);
        public static void Save<TItem>(this TItem item)
        {
            try
            {
                if (!item.IsDirty) return;
                instance.SaveItem(item);
            }
            catch (Exception ex)
            {
                throw new ItemSaveException();
            }
        }
        public static TItem Get(long id, long callerId)
        {
            Item1 item;
            try
            {
                item = instance.GetItem(id, callerId);
            }
            catch (Exception ex)
            {
                throw new ItemRetrieveException();
            }
            return item;
        }
        public static List<TItem> List(long callerId)
        {       
            return instance.GetItemsByCallerId(callerId).Where(x => x.IsActive).ToList();
        }
        public static bool Delete(long id, long callerId)
        {
            try
            {
                instance.DeactivateItem(id, callerId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    public class Item1ManagerAdapter : ItemManagerAdapter<Item1>
    {
        protected override void SaveItem(Item1 item) { Item1Manager.SaveItem(item); }
        protected override Item1 GetItem(long id, long callerId) { return Item1Manager.GetItem(id, callerId); }
        protected override List<Item1> GetItemsByCallerId(long callerId) { return Item1Manager.GetItemsByCallerId(callerId); }
        protected override void DeactivateItem(long id, long callerId) { Item1Manager.DeactivateItem(id, callerId); }
    }
    public class Item2ManagerAdapter : ItemManagerAdapter<Item2>
    {
        protected override void SaveItem(Item2 item) { Item2Manager.SaveItem(item); }
        protected override Item2 GetItem(long id, long callerId) { return Item2Manager.GetItem(id, callerId); }
        protected override List<Item2> GetItemsByCallerId(long callerId) { return Item2Manager.GetItemsByCallerId(callerId); }
        protected override void DeactivateItem(long id, long callerId) { Item2Manager.DeactivateItem(id, callerId); }
    }
