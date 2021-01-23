    public class Wrong
    {
        private Property _property;
        public Property Property  
        { 
            get { return _property ?? new Property(); } // no assignment done to _property.
            set { _property = value; } 
        }
    }
