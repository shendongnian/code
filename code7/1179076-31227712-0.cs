        FileItem _myItem;
        public FileItem MyItem
        {
            get
            {
                return _myItem;
            }
            set
            {
                _myItem = value;
                OnPropertyChanged("MyItem");
            }
        }
        private void Selected()
        {
            string fileName = MyItem.FileName;
        }
