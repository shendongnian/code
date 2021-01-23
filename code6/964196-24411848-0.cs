    public class MyClass: IDisposable
    {
        private Stream _foo;
        public MyClass Get()
        {
            if (_foo == null)
            {
                _foo = new MemoryStream();
            }
        }
        public void Foo()
        {
            _foo.WriteByte(1);
        }
        public void Dispose()
        {
            if (_foo != null)
            {
                _foo.Dispose();
                _foo = null;
            }
        }
    }
