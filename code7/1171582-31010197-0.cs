    class MyClass
    {
        string _val1 = null;
        string _val2 = null;
        string _val3 = null;
        public string Val1
        {
            get
            {
                return _val1;
            }
            set
            {
                // do some stuff with _val1
                _val1 = value;
            }
        }
        public string Val2
        {
            get
            {
                return _val2;
            }
            set
            {
                // do some stuff with _val2
                _val2 = value;
            }
        }
    
        public string Val3
        {
            get
            {
                return _val3;
            }
            set
            {
                // do some stuff with _val3
                _val3 = value;
            }
        }
    
        public MyClass(){}
        public MyClass(string val_id1, string val_id2 = null, string val_id3 = null)
        {
            // Don't set _valX instead set ValX
        }
    }
