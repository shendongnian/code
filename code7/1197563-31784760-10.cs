    class Binder
    {
        public Binder()
        {
            _bindings = new Dictionary<string, List<string>>();
        }
        private INotifyPropertyChanged _dataContext;
        public INotifyPropertyChanged DataContext
        {
            get { return _dataContext; }
            set
            {
                if (_dataContext != null)
                {
                    _dataContext.PropertyChanged -= _dataContext_PropertyChanged;
                }
                _dataContext = value;
                _dataContext.PropertyChanged += _dataContext_PropertyChanged;
            }
        }
        void _dataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_bindings.ContainsKey(e.PropertyName))
            {
                var bindableType = _dataContext.GetType();
                var bindableProp = bindableType.GetProperty(e.PropertyName);
                if (bindableProp == null)
                {
                    return;
                }
                var binderType = this.GetType();
                foreach (var binderPropName in _bindings[e.PropertyName])
                {
                    var binderProp = binderType.GetProperty(binderPropName);
                    if (binderProp == null)
                    {
                        continue;
                    }
                    var value = bindableProp.GetValue(_dataContext);
                    binderProp.SetValue(this, value);
                }
            }
        }
        Dictionary<string, List<string>> _bindings;
        public void AddBinding(string binderPropertyName, string bindablePropertyName)
        {
            if (!_bindings.ContainsKey(bindablePropertyName))
            {
                _bindings.Add(bindablePropertyName, new List<string>());
            }
            _bindings[bindablePropertyName].Add(bindablePropertyName);
        }
    }
    class Bindable : INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
