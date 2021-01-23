        private string _selectedLists;
        public string SelectedLists
        {
            get { return _selectedLists; }
            set
            {
                _selectedLists = value;
                ItemsPicked(value); // <----------------
                NotifyOfPropertyChange(() => SelectedLists);
            }
        }
        private void ItemsPicked(string selectedValue)
        {
            //Handle selection
        }
