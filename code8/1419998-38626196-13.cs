    public class StatusFactory
    {
        private List<Status> _possibleStatus;
        public StatusFactory()
        {
            _possibleStatus = new List<Status>();
            _possibleStatus.Add(new StatusInfo());
            _possibleStatus.Add(new StatusSql());
            _possibleStatus.Add(new StatusDefault());
        }
        public StatusFactory(IEnumerable<Status> possibleStatus)
        {
            _possibleStatus = new List<Status>();
            _possibleStatus.AddRange(possibleStatus);
        }
        public Status BuildMessageStatus(string message)
        {
            int currentIndex = -1;
            Status messageStatus = new StatusDefault();
            foreach(var status in _possibleStatus)
            {
                var statusIndex = status.GetIndex(message);
                if(statusIndex > -1 && ((currentIndex != -1 && statusIndex < currentIndex) || (currentIndex == -1)))
                {
                    currentIndex = statusIndex;
                    messageStatus = status;
                }
            }
            return messageStatus;
        }
    }
