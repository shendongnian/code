        private bool showHide;
        public bool ShowHide
        {
            get { return showHide; }
            set { showHide = value;
            OnPropertyChanged("ShowHide"); }
        }
