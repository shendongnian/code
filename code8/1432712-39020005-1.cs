     public bool IsExpandedProp
        {
            get { return _IsExpandedProp; }
            set { _Values = _IsExpandedProp; NotifyPropertyChanged(); }
        }
