    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            TimeLine first = new TimeLine();
            first.Duration = new TimeSpan(1, 0, 0);
            first.Events.Add(new TimeLineEvent() { Start = new TimeSpan(0, 15, 0), Duration = new TimeSpan(0, 15, 0) });
            first.Events.Add(new TimeLineEvent() { Start = new TimeSpan(0, 40, 0), Duration = new TimeSpan(0, 10, 0) });
            this.TimeLines.Add(first);
            TimeLine second = new TimeLine();
            second.Duration = new TimeSpan(1, 0, 0);
            second.Events.Add(new TimeLineEvent() { Start = new TimeSpan(0, 0, 0), Duration = new TimeSpan(0, 25, 0) });
            second.Events.Add(new TimeLineEvent() { Start = new TimeSpan(0, 30, 0), Duration = new TimeSpan(0, 15, 0) });
            second.Events.Add(new TimeLineEvent() { Start = new TimeSpan(0, 50, 0), Duration = new TimeSpan(0, 10, 0) });
            this.TimeLines.Add(second);
        }
        private ObservableCollection<TimeLine> _timeLines = new ObservableCollection<TimeLine>();
        public ObservableCollection<TimeLine> TimeLines
        {
            get
            {
                return _timeLines;
            }
            set
            {
                Set(() => TimeLines, ref _timeLines, value);
            }
        }
        
    }
    public class TimeLineEvent : ObservableObject
    {
        private TimeSpan _start;
        public TimeSpan Start
        {
            get
            {
                return _start;
            }
            set
            {
                Set(() => Start, ref _start, value);
            }
        }
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                Set(() => Duration, ref _duration, value);
            }
        }
        
    }
    public class TimeLine : ObservableObject
    {
        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                Set(() => Duration, ref _duration, value);
            }
        }
        
        private ObservableCollection<TimeLineEvent> _events = new ObservableCollection<TimeLineEvent>();
        public ObservableCollection<TimeLineEvent> Events
        {
            get
            {
                return _events;
            }
            set
            {
                Set(() => Events, ref _events, value);
            }
        }
    }
  
