            public double StartTimeOnSlide
        {
            get { return _startTimeOnSlide; }
            set
            {
                Set(() => StartTimeOnSlide, ref _startTimeOnSlide, value);
              
                    SetSelectedGrapHStartIntervalExecute();
              
               
            }
        }
        public double StopTimeOnSlide
        {
            get { return _stopTimeOnSlide; }
            set
            {
                Set(() => StopTimeOnSlide, ref _stopTimeOnSlide, value);
                SetSelectedGrapHStopIntervalExecute();
            }
        }
        public double StartPointOfSlider
        {
            get { return _startPointOfSlider; }
            set
            {
                Set(() => StartPointOfSlider, ref _startPointOfSlider, value);
                RaisePropertyChanged();
            }
        }
        public double StopPointOfSlider
        {
            get { return _stopPointOfSlider; }
            set
            {
                Set(() => StopPointOfSlider, ref _stopPointOfSlider, value);
                RaisePropertyChanged();
            }
        }
