        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    //perform your ItemChange events here, if you have any
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
     
