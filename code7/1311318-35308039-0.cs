    public class ServiceReturnInformation<T>
    {
        public T DataContext { get; set; }
        private IList<string> _warnings;
        public IList<string> Warnings
        {
            get { return _warnings ?? (_warnings = new List<string>()); }
            set { _warnings = value; }
        }
        private IList<string> _errors;
        public IList<string> Errors
        {
            get { return _errors ?? (_errors = new List<string>()); }
            set { _errors = value; }
        }
    }  
