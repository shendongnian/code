     private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
                Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                {
                    ProgressPercent += 10; //handle the fact that this needs to be added once using a bool or something 
                });
                
            }
        }
