    public void PushItem(Item item)
    {
        _items.Push(item);
        OnPropertyChanged(nameof(IsVisible)); // implement INotifyPropertyChanged
    }
    
