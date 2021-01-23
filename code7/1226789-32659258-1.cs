    public class Foo2Wrapper
    {
        private Foo2 _obj;
        
        public Foo2Wrapper(Foo2 obj)
        {
            _obj = obj;
        }
        public int x { get { return _obj.x; } }
    }
