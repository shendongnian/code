        private Brush background = new SolidColorBrush(Colors.Red);
        public Brush Background
        {
            get { return background; }
            set
            {
                background = value;
                OnPropertyChanged();
            }
        }
