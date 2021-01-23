    struct MyStruct
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set
            { 
                if (_name == value) return;
                GlobalStorageClass.myStructs.Remove(_name);
                _name = value;
                GlobalStorageClass.myStructs.Add(_name, this);
            }
        }
        public MyStruct(string name)
        {
            _name = name;
            GlobalStorageClass.myStructs.Add(name, this);
        }
    }
