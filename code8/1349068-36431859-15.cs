     public class MainViewModel : INotifyPropertyChanged {
        public IEnumerable<TestDataItem> Items => new[] {
                new TestDataItem() {ID = 100, Text = "item1"},
                new TestDataItem() {ID = 200, Text = "item2"},
                new TestDataItem() {ID = 300, Text = "item3"}
            };
        private string _statusText = "No data selected";
        public string StatusText
        {
            get { return _statusText; }
            set
            {
                if (value == _statusText) return;
                _statusText = value;
                OnPropertyChanged();
            }
        }
        private TestDataItem _selectedItem;
        public TestDataItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
