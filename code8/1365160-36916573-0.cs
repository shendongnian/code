        public MainWindowVM()
        {
            this.RowCount = 4;
            this.ColumnCount = 5;
        }
        private int _RowCount;
        public int RowCount
        {
            get { return _RowCount; }
            set { _RowCount = value; NotifyPropertyChanged("RowCount"); }
        }
        private int _ColumnCount;
        public int ColumnCount
        {
            get { return _ColumnCount; }
            set { _ColumnCount = value; NotifyPropertyChanged("ColumnCount"); }
        }
