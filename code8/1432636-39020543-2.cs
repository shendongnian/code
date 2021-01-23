    #region EditItem Property
    private Item _editItem = null;
    public Item EditItem
    {
        get { return _editItem; }
        protected set
        {
            if (value != _editItem)
            {
                _editItem = value;
                if (_editItem == null)
                {
                    _editItemOriginal = null;
                }
                OnPropertyChanged();
                EditItemCommand.RaiseCanExecuteChanged();
                SaveItemCommand.RaiseCanExecuteChanged();
                CancelEditCommand.RaiseCanExecuteChanged();
            }
        }
    }
    private Item _editItemOriginal;
    protected void EditThisItem(Item item)
    {
        EditItem = new Item(item);
        _editItemOriginal = item;
    }
    #endregion EditItem Property
