     private object _CurrentViewModel;
     public object CurrentViewModel
     {
            get { return _CurrentViewModel; }
            set { _CurrentViewModel = value; NotifyPropertyChanged(); }
     }
