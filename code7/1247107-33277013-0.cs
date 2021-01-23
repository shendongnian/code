        private double _start;
        private double _duration;
        private double _end;
        public double Start
        {
            get
            {
                return _start;
            }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    Duration = _end - _start;
                    OnPropertyChanged("Start");
                }
            }
        }
        public double Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    End = _duration + _start;
                    OnPropertyChanged("Duration");
                }
            }
        }
        public double End
        {
            get
            {
                return _end;
            }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    Duration = _end - _start;
                    OnPropertyChanged("End");
                }
            }
        }
