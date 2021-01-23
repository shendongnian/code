    public class Right
    {
        private Property _property;
        public Property Property 
        { 
            get { return _property; } 
            set { _property = value ?? new Property(); }  //initialized and assigned to _property
        }
    }
