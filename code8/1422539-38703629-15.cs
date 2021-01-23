    public ObservableCollection<Item> AllItems
    {
        get { return _allItems; }
        set
        {
            _allItems = value;
            OnPropertyChanged();
         }
    }
    public Item MySelectedItem
    {
        get { return _mySelectedItem; }
        set
        {
            _mySelectedItem = value;
            OnPropertyChanged();
            foreach (var item in AllItems)
            {
                item.IsExtraControlsVisible = false;
            }
            var selectedItem = AllItems.FirstOrDefault(x => x.Equals(value));
            if (selectedItem != null)
            {
                selectedItem.IsExtraControlsVisible = true;
            }
        }
    }
