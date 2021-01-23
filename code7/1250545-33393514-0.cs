        private object _CurrentItem;
        public object CurrentItem
        {
            get
            {
                return _CurrentItem;
            }
            set
            {
                _CurrentDocument = value;
                NotifyPropertyChanged();
                //Make your logic for your combobox binding.
            }
        }
