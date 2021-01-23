    public class MainViewModel
    {
        public Status CurrentStatus { get; set; }
        public IEnumerable<Status> Statuses
        {
            get
            {
                return new Status[]
                {
                    Status.Available,
                    Status.Away
                };
            }
        }
    }
