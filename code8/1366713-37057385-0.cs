        private ObservableCollection<DataClass> dataGridItems = new ObservableCollection<DataClass>();
        public ObservableCollection<DataClass> DataGridItems
        {
            get { return dataGridItems; }
            set { SetProperty(ref dataGridItems, value); }
        }
