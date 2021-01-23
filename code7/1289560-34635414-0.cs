    public class MyObject : PropertyChangedBase
    {
        public DateTime Time { get; set; }
        public String Desc { get; set; }
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange();
            }
        }
    }
