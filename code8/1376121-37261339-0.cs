    public class ObjectUnderTest : IDisposable
    {
        private IObjectNeedingDisposal _foo;
        public IObjectNeedingDisposal Foo
        {
            get { return _foo ?? (_foo = new ObjectNeedingDisposal()); }
            set { _foo = value; }
        }
        public void MethodUsingDisposable()
        {
            Foo.DoStuff();
        }
        public void Dispose()
        {
            Foo.Dispose();
        }
    }
