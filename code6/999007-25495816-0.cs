    public class MyTBLViewModel : INotifyPropertyChanged
    {
        public MyTBL Entity
        {
            get { return _entity; }
        }
        private readonly MyTBL _entity;
        public Brush Highlight
        {
            get { return _brush; }
            set
            {
                _brush = value;
                RaisePropertyChanged("Highlight");
            }
        }
        private Brush _highlight;
        public double ItemFontSize
        {
            get { return _itemFontSize; }
            set
            {
                _itemFontSize = value;
                RaisePropertyChanged("ItemFontSize");
            }
        }
        private Brush _itemFontSize;
        public MyTBLViewModel(MyTBL entity)
        {
            _entity = entity;
            _highlight = new SolidColorBrush(Colors.Transparent);
            _itemFontSize = 12;
        }
        public event PropertyChangedEventArgs PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propName));
        }
    }
