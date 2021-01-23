    public class ViewModelPageBase : ViewModelBase
    {
        private string _caption;
        public string Caption
        {
            get { return _caption; }
            protected set // will be set in constructor of inherited page
            {
                if (value != _caption)
                {
                    _caption = value;
                    OnPropertyChanged("Caption");
                }
            }
        } 
        
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _selected)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
    }
