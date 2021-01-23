    public struct TimeSlot
    {
        private DateTime _start;
        private TimeSpan _span;
    
        public DateTime Start
        {
            get
            {
                if (_start == null)
                {
                    _start = DateTime.Today;
                }
                return _start;
            }
    
            set
            {
                _start = value;
            }
        }
    
        public TimeSpan Span
        {
            get
            {
                if (_span == null)
                {
                    _span = new TimeSpan(0);
                }
                return _span;
            }
    
            set
            {
                if (value.Ticks >= 0)
                {
                    _span = value;
                }
            }
        }
    
        public DateTime End
        {
            get
            {
                return Start.Add(Span);
            }
        }
    
        public TimeSlot(DateTime start, TimeSpan span)
        {
            _start = start;
            _span = span.Ticks >= 0 ? span : new TimeSpan(0);
        }
    }
