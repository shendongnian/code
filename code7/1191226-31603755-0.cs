    struct MyClass
    {
        private string _name;
        public MyClass(string name)
        {
            _name = name;
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
