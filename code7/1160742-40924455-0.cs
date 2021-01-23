    public class Impl : IFoo
    {
        private readonly string _testFoo;
        string IFoo.TestFoo => _testFoo;
        public Impl(string value)
        {
            _testFoo = value;
        }
    }
