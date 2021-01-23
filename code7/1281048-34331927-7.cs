        private GridState _gridBackground;
        public GridState GridBackground
        { 
            get { return _gridBackground; }
            set
            {
                _gridBackground = value;
                NotifyPropertyChanged();
            }
        }
