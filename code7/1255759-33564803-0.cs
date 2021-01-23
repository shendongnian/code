        private ObservableCollection<UIElement> mapElements = new ObservableCollection<UIElement>();
        public ObservableCollection<UIElement> MapElements
        {
            get
            {
                return mapElements;
            }
            set
            {
                mapElements = value;
                OnPropertyChanged("MapElements");
            }
        }
