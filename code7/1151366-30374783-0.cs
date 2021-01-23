    public class MemberUser : INotifyPropertyChanged
    {
        public int member_id { get; private set; }
        public String first_name { get; private set; }
        public String last_name { get; private set; }
        public string fullName
        {
            get
            {
                return String.Format("{0} {1}", first_name, last_name);
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged("selectedImage");
            }
        }
        private bool _isSelected;
        public string selectedImage
        {
            get
            {
                if (IsSelected)
                {
                    return "/Assets/ic_selected.png";
                }
                else
                {
                    return "/Assets/ic_not_selected.png";
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
