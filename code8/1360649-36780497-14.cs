    public struct ImmutableStruct
    {
        private readonly int _field1;
        private readonly string _field2;
        private readonly object _field3;
        public ImmutableStruct(int f1, string f2, object f3)
        {
            _field1 = f1;
            _field2 = f2;
            _field3 = f3;
        }
        public int Field1 { get { return _field1; } }
        public string Field2 { get { return _field2; } }
        public object Field3 { get { return _field3; } }
    }
