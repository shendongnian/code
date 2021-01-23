    struct MyStruct 
    {
        private bool _f;
        public bool f {
            get { return _f != 0; }
            set { _f = value ? 1 : 0; }
        }
    }
