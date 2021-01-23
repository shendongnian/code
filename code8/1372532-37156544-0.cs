    internal class SomeUser
    {        
        private string _name;
        private string _address;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
