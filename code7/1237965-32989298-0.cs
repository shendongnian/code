        private Visbility isContentVisible = Visibility.Visible;
        public Visbility IsContentVisible
        {
                get { return isContentVisible; }
                set 
                { 
                      isContentVisible = value; 
                      OnPropertyChanged("IsContentVisible");
                }
        }
