     private int _Progress;
        public int Progress
        {
            get { return _Progress; }
            set
            {
                _Progress= value;                
                NotifyPropertyChanged();
            }
        }
