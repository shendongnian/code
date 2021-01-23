    public class Items
    {
        public List<BaseItem> AllItems { get; private set; }
        public ObservableCollection<BaseItem> ItemList { get; private set; }
    
        public Items()
        {
            ItemList = new ObservableCollection<BaseItem>();
            AllItems = new List<BaseItem>();
        }
        public void Add(BaseItem item)
        {
            AllItems.Add(item);
    
            if (item is ItemGroup)
                ItemList.Add(item);
            else
                AllItems.OfType<ItemGroup>().Single(i => i.GroupId == item.GroupId).Notify();
            }
        }
    public class ItemGroup : BaseItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ItemGroup(Items _List): base(_List) { }
        public IEnumerator Children
        {
            get
            {
                return _List.AllItems
                    .OfType<SubItem>()
                    .Where(SI => SI.GroupId == this.GroupId)
                    .GetEnumerator();
            }
        }
        public void Notify()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Children)));
        }
    }
 
