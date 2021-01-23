    public class Ethernet : PropertyChangedBase
    {
        private string _timeStamp;
    
        public string TimeStamp
        {
            get { return _timeStamp; }
            set { SetProperty(value, ref _timeStamp); }
        }
    }
