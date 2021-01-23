    private KeyValuePair<string,string> _selectedItem  ;
        public KeyValuePair<string,string> SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem.Equals(value))
                {
                    return;
                }
                _selectedItem = value; 
                
            }
        }
