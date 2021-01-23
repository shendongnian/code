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
            Field = _item.Field;
        }
    }
    public object Field
    {
        get
        {
            return _field;
        }
        private set
        {
            _field = value;
            OnPropertyChanged("Field");
        }
    }
