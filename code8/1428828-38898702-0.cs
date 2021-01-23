    public MyClass Item
    {
        get
        {
            return _item;
        }
        protected set
        {
            _item = value;
            OnPropertyChanged("Item");
            OnPropertyChanged("Field");
        }
    }
