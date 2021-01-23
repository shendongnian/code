    class ViewModel0
    {
        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                if (//implement check if the new item needs to be pushed to the list here)
                {
                    items = value;
                    NotifyPropertyChanged();
                }
                
            }
        }
        public void addNewEntry(string value1, string value2)
        { 
            Item newItem = new Item(value1, value2);
            Items.Add(newItem);
        }
        public void addNewEntryWithCheck(string value1, string value2)
        {
            if (//implement check if the new item needs to be pushed to the list here)
            {
                Item newItem = new Item(value1, value2);
                Items.Add(newItem); 
            }
        }
    }
