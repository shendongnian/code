        class BaseViewModel //implement INotifyPropertyChanged if needed
        {
            public AppViewModel AppModel 
            {
                get { return AppViewModel.Current; }
            }
        }
