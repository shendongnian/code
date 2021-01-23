        public bool IsLocalSelected
        {
            get
            {
                return pIsLocalSelected;
            }
            set //LocalSelected is Set: -> UnSet Server
            {
                pIsLocalSelected = value;
                OnPropertyChanged("IsLocalSelected");
                IsServerSelected = false;
                OnPropertyChanged("IsServerSelected");
            }
        }
        public bool IsServerSelected
        {
            get
            {
                return pIsServerSelected;
            }
            set //ServerSelected is Set: -> UnSet Local
            {
                pIsServerSelected = value;
                OnPropertyChanged("IsServerSelected");
                IsLocalSelected = false;
                OnPropertyChanged("IsLocalSelected");
            }
        }
