    class BinderElement : Binder
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
    class BindableElement : Bindable
    {
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }
    }
