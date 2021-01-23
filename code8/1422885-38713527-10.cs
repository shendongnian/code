    public class CustomerEntity()
    {
        string _name;
        public string Name 
        {
            get { return _name; }
            set { _name = value.ToUpper(); } // Check for null ?
        }
    }
