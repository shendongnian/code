    public int LastValidIndex
    {
        get { return _lastIndex; }
        set
        {
            if (value == -1) return;
            _lastIndex = value;
            OnPropertyChanged();
        }
    }
    public string CurrentFullName
    {
        get
        {
            return SelectedItem.FullName;
        }
        set
        {
            var currentItem = SelectedItem;
            ComboBoxItemsCollection.RemoveAt(LastValidIndex);
            currentItem.FullName = value;
            ComboBoxItemsCollection.Insert(LastValidIndex, currentItem);
            SelectedItem = currentItem;
        }
    }
