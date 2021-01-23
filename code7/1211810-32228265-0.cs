        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if(PropertyChanged != null)
                    PropertyChanged(this,new PropertyChangedEventArgs("SelectedItem"));
                DoKontoEdit.OnCanExecuteChanged();
            }
        }
        
