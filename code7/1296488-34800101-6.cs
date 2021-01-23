    public class ArrowItem:INotifyPropertyChanged
    {
        private string _title;
        private string _date;
        private string _imgLink;
        private ImageSource _img;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }
        public String Date
        {
            get { return _date; }
            set
            {
                if (value == _date) return;
                _date = value;
                OnPropertyChanged();
            }
        }
        public String ImgLink
        {
            get { return _imgLink; }
            set
            {
                if (value == _imgLink) return;
                _imgLink = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Img
        {
            get { return _img; }
            set
            {
                if (Equals(value, _img)) return;
                _img = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
