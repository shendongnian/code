    class BindableList<T> : List<T> where T : Bindable
    {
        public event Action<T> ItemAdded;
        public new void Add(T item)
        {
            base.Add(item);
            NotifyItemAdded(item);
        }
        private void NotifyItemAdded(T item)
        {
            if (ItemAdded != null)
            {
                ItemAdded(item);
            }
        }
    }
    class BinderList<T> : List<T> where T : Binder
    {
        public BinderList()
        {
            _bindingRules = new Dictionary<string, string>();
        }
        private BindableList<Bindable> _dataContextList;
        public BindableList<Bindable> DataContextList
        {
            get { return _dataContextList; }
            set
            {
                if (_dataContextList != null)
                {
                    _dataContextList.ItemAdded -= _dataContextList_ItemAdded;
                }
                _dataContextList = value;
                _dataContextList.ItemAdded += _dataContextList_ItemAdded;
            }
        }
        void _dataContextList_ItemAdded(Bindable obj)
        {
            foreach (var pair in _bindingRules)
            {
                this[Count-1].AddBinding(pair.Key, pair.Value);
                this[Count - 1].DataContext = obj;
            }
        }
        private Dictionary<string, string> _bindingRules;
        public void AddBindingRule(string binderPropertyName, string bindablePropertyName)
        {
            _bindingRules.Add(binderPropertyName, bindablePropertyName);
        }
    }
