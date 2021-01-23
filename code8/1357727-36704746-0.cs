    sealed class SelectionViewModel
    {
        private bool _setByTarget = false;
    
        internal SelectionViewModel( )
        {
            this.WhenAnyValue(x => x.Target).Where(t => t != null)
                .Select(_ => Target.SpecialValue)
                .Do(_ => _setByTarget = true)
                .BindToProperty(this, x => x.SelectedItem);
    
            this.WhenAnyValue(x => x.Target)
                .Where(t => t != null && !_setByTarget )
                .Select(_ => this.WhenAnyValue(x => x.SelectedItem))
                .Switch()
                .BindToProperty(this, x => Target.SpecialValue);
            this.WhenAnyValue(x => x.Target)
                .Where(!_setByTarget)
                .Subscribe(_ => _setByTarget = false);
        }
    
        private MyClass _selectedItem;
    
        public MyClass SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
    
        private ITarget _target;
    
        public ITarget Target
        {
            get { return _target; }
            set { SetProperty(ref _target, value); }
        }
    }
