    public class TabsViewModel
    {
        public TabsViewModel()
        {
            this.Items = GetItems();
        }
        private TabItemModel _SelectedItem;
        public TabItemModel SelectedItem
        {
            get
            {
                return this._SelectedItem;
            }
            set
            {
                if (value == this._SelectedItem)
                    return;
                if (value != null)
                {
                    if (this._SelectedItem != null)
                        this._SelectedItem.IsSelected = false;
                    value.IsSelected = true;
                }
                this._SelectedItem = value;
            }
        }
        
        public ObservableCollection<TabItemModel> Items
        {
            get;
            private set;
        }
        private ObservableCollection<TabItemModel> GetItems()
        {
            return new ObservableCollection<TabItemModel>()
            {
                new TabItemModel("Tab 1", 
                    new TabItemModel[] 
                    {
                        new TabItemModel("Tab 1 - SubTab 1"),
                        new TabItemModel("Tab 1 - SubTab 2")
                    }),
                new TabItemModel("Tab 2", 
                    new TabItemModel[] 
                    {
                        new TabItemModel("Tab 2 - SubTab 1"),
                        new TabItemModel("Tab 2 - SubTab 2")
                    }),
                new TabItemModel("Tab 3", 
                    new TabItemModel[] 
                    {
                        new TabItemModel("Tab 3 - SubTab 1"),
                        new TabItemModel("Tab 3 - SubTab 2")
                    })
            };
        }
    }
