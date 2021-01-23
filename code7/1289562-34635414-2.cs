        BindableCollection<MyObject> _items = new BindableCollection<MyObject>();
        public BindableCollection<MyObject> Items
        {
            get
            {
                return _items;
            }
        }    
        public BindableCollection<MyObject> SelectedItems
        {
            get
            {
                _selectedItems.Clear();
                _selectedItems.AddRange(Items.Where(mo => mo.IsSelected));
                return _selectedItems;           
            }
        }
