    public class StructureVm : IStructureManager
    {
        private readonly ObservableCollection<Model> _items;
        private readonly string _title;
        public StructureVm(string title)
        {
            _title = title;
            _items = new ObservableCollection<Model>
                {
                    new Model(this, "12"),
                    new Model(this, "23"),
                    new Model(this, "34"),
                    new Model(this, "45"),
                    new Model(this, "56"),
                    new Model(this, "67"),
                    new Model(this, "78"),
                    new Model(this, "89"),
                };
        }}
        public ObservableCollection<Model> Items
        {
            get
            {
                return _items;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public bool RemoveItem(Model itemToRemove)
        {
            return _items.Remove(itemToRemove);
        }
    }
