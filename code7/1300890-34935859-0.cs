    public abstract class ContainerViewModel : BindableBase
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public ItemViewModel ActiveItem { get; set; }
        protected virtual void Add(ItemViewModel item) { ... }
        protected virtual void Remove(ItemViewModel item) { ... }
        protected virtual void Activate(ItemViewModel item) { ... }
    }
