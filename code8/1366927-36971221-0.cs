    private int _SelectedIndex = 0;
        public int SelectedIndex 
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = value;
                RaisePropertyChanged(nameof(SelectedIndex));
            }
        }
    private Category _SelectedQuality = null;
        public Category SelectedQuality
        {
            get
            {
                return _SelectedQuality;
            }
            set
            {
                _SelectedCategory = value;
                RaisePropertyChanged(nameof(SelectedCategory ));
            }
        }
