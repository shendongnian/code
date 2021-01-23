    class User
    {
        private string _name;
        
        public User(string name)
        {
            _name = name;
        }
        public string Name // this is the property
        {
            get { return _name; }  //  GetName
            set { _name = value; } //  SetName
        }
        public override string ToString() // this is called when you do user.ToString()
        {
            return string.Format("Name : {0}", Name); // return needed information.
        }
    }
