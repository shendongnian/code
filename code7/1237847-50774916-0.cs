    public class PersonError
    {
        private List<string> _roles;
    
        public string Name { get; set; }
        public int Age { get; set; }
    
        public List<string> Roles
        {
            get
            {
                if (_roles == null)
                {
                    throw new Exception("Roles not loaded!");
                }
    
                return _roles;
            }
            set { _roles = value; }
        }
    
        public string Title { get; set; }
    
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
