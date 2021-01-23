    public class Foo : INotifyPropertyChanged
    {
        private Bar _bar1;
        public Bar Item
        {
            get { return _bar1; }
            set 
            { 
                 SetField(ref _bar1, value); 
                 ItemChanged();
            }
        }
        public string MyString
        {
            get { return _bar1.Item; }
        }
        private void ItemChanged()
        {
            OnPropertyChanged("MyString");
        }
    }
    public class Bar
    {
        public string Item { get; set; }
    }
