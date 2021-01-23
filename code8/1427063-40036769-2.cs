        //Method to update the ListView to show items based on the letter of the slider
        public RoutedEventHandler ValueChanged;
		public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                NotifyPropertyChanged("SliderValue");
                char letter = (char)_sliderValue;
                var items = ItemsGroup.FirstOrDefault(i => (char)i.Key == letter);
                if (items == null) return;
                ValueChanged(items.FirstOrDefault(), new RoutedEventArgs());
            }
        }
